using _08_Organic_DesignPatternsProject.ChainOfResponsibility.Abstract;
using _08_Organic_DesignPatternsProject.Repositories.CouponRepository;

namespace _08_Organic_DesignPatternsProject.ChainOfResponsibility.Handlers
{
    public class CouponHandler : OrderHandler
    {
        private readonly ICouponRepository _couponRepository;

        public CouponHandler(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public override async Task<string> Handle(OrderRequest request)
        {
            if (!string.IsNullOrEmpty(request.CouponCode))//kupon kodu girildiyse
            {
                var coupon = await _couponRepository.GetByCodeAsync(request.CouponCode);

                if (coupon == null)
                {
                    return "Girilen kupon kodu geçersiz.";
                }
                if (coupon.IsUsed == true)
                {
                    return "Bu kopon kodu daha önce kullanılmıştır.";
                }
                if (coupon.ExpiryDate < DateTime.Now)
                {
                    return "Bu kupon kodunun süresi dolmuştur.";
                }
            }
            if (_nextHandler != null)
            {
                return await _nextHandler.Handle(request);
            }
            return null;
        }
    }
}
