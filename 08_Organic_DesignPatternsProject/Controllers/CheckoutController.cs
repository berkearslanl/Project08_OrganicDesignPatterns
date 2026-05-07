using _08_Organic_DesignPatternsProject.ChainOfResponsibility;
using _08_Organic_DesignPatternsProject.ChainOfResponsibility.Abstract;
using _08_Organic_DesignPatternsProject.Entities;
using _08_Organic_DesignPatternsProject.Enums;
using _08_Organic_DesignPatternsProject.Models;
using _08_Organic_DesignPatternsProject.Observer;
using _08_Organic_DesignPatternsProject.Repositories.CartRepository;
using _08_Organic_DesignPatternsProject.Repositories.CouponRepository;
using _08_Organic_DesignPatternsProject.Repositories.OrderRepository;
using _08_Organic_DesignPatternsProject.Strategies;
using _08_Organic_DesignPatternsProject.Strategies.Concrete;
using _08_Organic_DesignPatternsProject.Strategies.Interfaces;
using _08_Organic_DesignPatternsProject.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _08_Organic_DesignPatternsProject.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICouponRepository _couponRepository;
        private readonly OrderValidationChain _orderValidationChain;//chainofresponsibility
        private readonly PaymentContext _paymentContext;//strategy
        private readonly IUnitOfWork _unitOfWork;//unitofwork
        private readonly OrderNotificationService _orderNotificationService;//observer

        public CheckoutController(ICartRepository cartRepository, IOrderRepository orderRepository, ICouponRepository couponRepository, OrderValidationChain orderValidationChain, PaymentContext paymentContext, IUnitOfWork unitOfWork, OrderNotificationService orderNotificationService)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
            _couponRepository = couponRepository;
            _orderValidationChain = orderValidationChain;
            _paymentContext = paymentContext;
            _unitOfWork = unitOfWork;
            _orderNotificationService = orderNotificationService;
        }
        private string GetSessionId()//sisteme giren her kullanıcıya özel sepet id'si oluşturur.(login işlemine gerek kalmadan her kullanıcının sepeti ona özel olur)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("CartSessionId")))
            {
                HttpContext.Session.SetString("CartSessionId", Guid.NewGuid().ToString());
            }
            return HttpContext.Session.GetString("CartSessionId");
        }
        public async Task<IActionResult> Index()
        {
            var sessionId = GetSessionId();
            var cart = await _cartRepository.GetBySessionIdAsync(sessionId);

            if (cart == null || !cart.CartItems.Any())
            {
                return RedirectToAction("Index", "Cart");
            }
            var model = new CheckoutViewModel
            {
                Cart = cart
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> PlaceOrder(CheckoutViewModel model)
        {
            var sessionId = GetSessionId();
            var cart = await _cartRepository.GetBySessionIdAsync(sessionId);
            model.Cart = cart;

            if (cart == null || !cart.CartItems.Any())
                return RedirectToAction("Index", "Cart");

            //ChainOfResponsibility sipariş doğrulama
            var orderRequest = new OrderRequest
            {
                CartItems = cart.CartItems.ToList(),
                CouponCode = model.CouponCode,
                TotalAmount = cart.CartItems.Sum(x => x.Product.Price * x.Quantity),
                PaymentMethod = model.PaymentMethod
            };

            var chain = _orderValidationChain.Build();
            var validationError = await chain.Handle(orderRequest);

            if (validationError != null)
            {
                model.ErrorMessage = validationError;
                return View("Index", model);
            }

            //strategy ödeme işlemi
            IPaymentStrategy strategy = model.PaymentMethod switch
            {
                "CreditCard" => new CreditCardPayment(),
                "CashOnDelivery" => new CashOnDeliveryPayment(),
                "BankTransfer" => new BankTransferPayment(),
                _ => throw new Exception("Geçersiz ödeme yöntemi")
            };

            _paymentContext.SetStrategy(strategy);

            var paymentRequest = new PaymentRequest
            {
                Amount = orderRequest.TotalAmount,
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail,
                CardNumber = model.CardNumber,
                CardHolderName = model.CardHolderName,
                ExpiryDate = model.ExpiryDate,
                CVV = model.CVV
            };

            var paymentResult = await _paymentContext.ExecutePaymentAsync(paymentRequest);

            if (!paymentResult.IsSuccess)
            {
                model.ErrorMessage = paymentResult.Message;
                return View("Index", model);
            }

            //unit of work sipariş oluşturma

            Coupon coupon = null;
            decimal totalAmount = orderRequest.TotalAmount;

            if (!string.IsNullOrEmpty(model.CouponCode))
            {
                coupon = await _couponRepository.GetByCodeAsync(model.CouponCode);
                if (coupon != null)
                    totalAmount -= coupon.DiscountAmount;
            }

            var order = new Order
            {
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail,
                CustomerPhone = model.CustomerPhone,
                Address = model.Address,
                TotalAmount = totalAmount,
                CreatedAt = DateTime.Now,
                Status = "Hazırlanıyor",
                CouponId = coupon?.CouponId,
                PaymentMethod = Enum.Parse<PaymentMethod>(model.PaymentMethod),
                OrderItems = cart.CartItems.Select(x => new OrderItem
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    UnitPrice = x.Product.Price
                }).ToList(),
            };

            await _orderRepository.CreateAsync(order);
            await _unitOfWork.CommitAsync(); // tüm işlemler için tek bir savechanges

            if (coupon != null)
                await _couponRepository.MarkAsUsedAsync(coupon.CouponId);//kupon girilmişse kullanıldı yap

            await _cartRepository.ClearCartAsync(cart.CartId);//sepeti temizle

            //observer
            await _orderNotificationService.NotifyOrderCreatedAsync
                (
                    order.CustomerEmail,
                    order.OrderId,
                    order.TotalAmount
                );

            return RedirectToAction("Confirmation", new { orderId = order.OrderId });
        }
        public async Task<IActionResult> Confirmation(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            return View(order);
        }
    }
}
