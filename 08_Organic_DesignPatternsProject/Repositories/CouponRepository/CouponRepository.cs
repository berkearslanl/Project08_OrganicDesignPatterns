using _08_Organic_DesignPatternsProject.Context;
using _08_Organic_DesignPatternsProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace _08_Organic_DesignPatternsProject.Repositories.CouponRepository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly OrganicContext _context;

        public CouponRepository(OrganicContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Coupon coupon)
        {
            await _context.Coupons.AddAsync(coupon);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _context.Coupons.FindAsync(id);
            _context.Coupons.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Coupon>> GetAllAsync()
        {
            return await _context.Coupons.ToListAsync();
        }

        public async Task<Coupon> GetByCodeAsync(string code)
        {
            return await _context.Coupons.FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task MarkAsUsedAsync(int id)
        {
            var value = await _context.Coupons.FindAsync(id);
            value.IsUsed = true;
            await _context.SaveChangesAsync();
        }
    }
}
