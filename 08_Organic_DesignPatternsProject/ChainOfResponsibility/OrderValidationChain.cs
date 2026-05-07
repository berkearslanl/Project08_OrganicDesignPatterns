using _08_Organic_DesignPatternsProject.ChainOfResponsibility.Abstract;
using _08_Organic_DesignPatternsProject.ChainOfResponsibility.Handlers;
using _08_Organic_DesignPatternsProject.Repositories.CouponRepository;
using System.Threading.Tasks;

namespace _08_Organic_DesignPatternsProject.ChainOfResponsibility
{
    public class OrderValidationChain
    {
        private readonly StockHandler _stockHandler;
        private readonly CouponHandler _couponHandler;
        private readonly MinOrderHandler _minOrderHandler;
        private readonly PaymentHandler _paymentHandler;

        public OrderValidationChain(ICouponRepository couponRepository)
        {
            _stockHandler = new StockHandler();
            _couponHandler = new CouponHandler(couponRepository);
            _minOrderHandler = new MinOrderHandler();
            _paymentHandler = new PaymentHandler();
        }
        public OrderHandler Build()
        {
            _stockHandler
                .SetNext(_couponHandler)
                .SetNext(_minOrderHandler)
                .SetNext(_paymentHandler);

            return _stockHandler;
        }
    }
}
