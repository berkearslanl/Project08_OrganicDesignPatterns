using _08_Organic_DesignPatternsProject.Context;
using _08_Organic_DesignPatternsProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.TrendRepository
{
    public class TrendRepository:ITrendRepository
    {
        private readonly OrganicContext _context;

        public TrendRepository(OrganicContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Trend trend)
        {
            await _context.Trends.AddAsync(trend);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _context.Trends.FindAsync(id);
            if (value != null)
                _context.Trends.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Trend>> GetAllAsync()
        {
            var values = await _context.Trends.ToListAsync();
            return values;
        }

        public async Task<Trend> GetByIdAsync(int id)
        {
            var value = await _context.Trends.FindAsync(id);
            if (value != null)
                return value;
            return null;
        }

        public async Task UpdateAsync(Trend trend)
        {
            _context.Trends.Update(trend);
            await _context.SaveChangesAsync();
        }
    }
}
