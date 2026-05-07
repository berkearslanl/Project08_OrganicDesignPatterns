using _08_Organic_DesignPatternsProject.Entities;

namespace _08_Organic_DesignPatternsProject.Repositories.CouponRepository
{
    public interface ICouponRepository
    {
        Task<List<Coupon>> GetAllAsync();
        Task<Coupon> GetByCodeAsync(string code);//girilen koda göre çağırma işlemi
        Task MarkAsUsedAsync(int id);//siparişten sonra kullanıldı olarak işaretlencek
        Task CreateAsync(Coupon coupon);
        Task DeleteAsync(int id);
    }
}
