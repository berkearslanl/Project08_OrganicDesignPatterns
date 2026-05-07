using _08_Organic_DesignPatternsProject.Entities;
using _08_Organic_DesignPatternsProject.Repositories.CartRepository;
using _08_Organic_DesignPatternsProject.Repositories.ProductRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _08_Organic_DesignPatternsProject.Controllers
{
    public class CartController : Controller
    {
        private string GetSessionId()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("CartSessionId")))
            {
                HttpContext.Session.SetString("CartSessionId", Guid.NewGuid().ToString());
            }
            return HttpContext.Session.GetString("CartSessionId");
        }
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;


        public CartController(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var sessionId = GetSessionId();//siteye giren kullanıcıyı tanımak içni id
            var cart = await _cartRepository.GetBySessionIdAsync(sessionId);//bu idye ait sepeti getir
            return View(cart);
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            var sessionId = GetSessionId();

            //eğer sessionId nin sepeti varsa onu getir
            var cart = await _cartRepository.GetBySessionIdAsync(sessionId);

            //yoksa o sessionId ye ait yeni sepet oluştur
            if (cart == null)
            {
                cart = new Cart
                {
                    CareatedAt = DateTime.Now,
                    SessionId = sessionId,
                    CartItems = new List<CartItem>()
                };
                await _cartRepository.CreateAsync(cart);
            }

            //eklenicek ürün sepette varsa
            var existingItem = cart.CartItems?.FirstOrDefault(x => x.ProductId == productId);//eğer o ürün yoksa null döner

            if (existingItem != null)
            {
                //eğer sepette varsa adedini güncelleme işlemi
                await _cartRepository.UptadeItemQuantityAsync(existingItem.CartItemId, existingItem.Quantity + quantity);
            }
            else
            {
                //sepette yoksa yeni ürün ekleme
                var cartItem = new CartItem
                {
                    CartId = cart.CartId,
                    ProductId = productId,
                    Quantity = quantity
                };
                await _cartRepository.AddItemAsync(cartItem);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveItem(int cartItemId)
        {
            await _cartRepository.RemoveItemAsync(cartItemId);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int cartItemId, int quantity)
        {
            if (quantity <= 0)
                await _cartRepository.RemoveItemAsync(cartItemId);
            else
                await _cartRepository.UptadeItemQuantityAsync(cartItemId, quantity);
            return RedirectToAction("Index");
        }
    }
}
