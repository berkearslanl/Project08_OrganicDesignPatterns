using _08_Organic_DesignPatternsProject.Context;
using _08_Organic_DesignPatternsProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.SaleBannerRepository
{
    public class SaleBannerRepository : ISaleBannerRepository
    {
        private readonly OrganicContext _context;

        public SaleBannerRepository(OrganicContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(SaleBanner saleBanner)
        {
            await _context.SaleBanners.AddAsync(saleBanner);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _context.SaleBanners.FindAsync(id);
            if (value != null)
                _context.SaleBanners.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SaleBanner>> GetAllAsync()
        {
            var values = await _context.SaleBanners.ToListAsync();
            return values;
        }

        public async Task<SaleBanner> GetByIdAsync(int id)
        {
            var value = await _context.SaleBanners.FindAsync(id);
            if (value != null)
                return value;
            return null;
        }

        public async Task UpdateAsync(SaleBanner saleBanner)
        {
            _context.SaleBanners.Update(saleBanner);
            await _context.SaveChangesAsync();
        }
    }
}
