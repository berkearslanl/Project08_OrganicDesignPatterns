using _08_Organic_DesignPatternsProject.Context;
using _08_Organic_DesignPatternsProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.BannerRepository
{
    public class BannerRepository : IBannerRepository
    {
        private readonly OrganicContext _context;

        public BannerRepository(OrganicContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Banner banner)
        {
            await _context.Banners.AddAsync(banner);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _context.Banners.FindAsync(id);
            if (value != null)
                _context.Banners.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Banner>> GetAllAsync()
        {
            var values = await _context.Banners.ToListAsync();
            return values;
        }

        public async Task<Banner> GetByIdAsync(int id)
        {
            var value = await _context.Banners.FindAsync(id);
            if(value!=null)
                return value;
            return null;
        }

        public async Task UpdateAsync(Banner banner)
        {
            _context.Banners.Update(banner);
            await _context.SaveChangesAsync();
        }
    }
}
