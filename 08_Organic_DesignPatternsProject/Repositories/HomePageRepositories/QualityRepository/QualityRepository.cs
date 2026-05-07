using _08_Organic_DesignPatternsProject.Context;
using _08_Organic_DesignPatternsProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.QualityRepository
{
    public class QualityRepository:IQualityRepository
    {
        private readonly OrganicContext _context;

        public QualityRepository(OrganicContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Quality quality)
        {
            await _context.Qualities.AddAsync(quality);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _context.Qualities.FindAsync(id);
            if (value != null)
                _context.Qualities.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<Quality> GetAllAsync()
        {
            return await _context.Qualities.FirstOrDefaultAsync();
        }

        public async Task<Quality> GetByIdAsync(int id)
        {
            var value = await _context.Qualities.FindAsync(id);
            if (value != null)
                return value;
            return null;
        }

        public async Task UpdateAsync(Quality quality)
        {
            _context.Qualities.Update(quality);
            await _context.SaveChangesAsync();
        }
    }
}
