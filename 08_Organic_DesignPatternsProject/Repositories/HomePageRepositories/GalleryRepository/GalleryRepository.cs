using _08_Organic_DesignPatternsProject.Context;
using _08_Organic_DesignPatternsProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.GalleryRepository
{
    public class GalleryRepository:IGalleryRepository
    {
        private readonly OrganicContext _context;

        public GalleryRepository(OrganicContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Gallery gallery)
        {
            await _context.Galleries.AddAsync(gallery);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _context.Galleries.FindAsync(id);
            if (value != null)
                _context.Galleries.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Gallery>> GetAllAsync()
        {
            var values = await _context.Galleries.ToListAsync();
            return values;
        }

        public async Task<Gallery> GetByIdAsync(int id)
        {
            var value = await _context.Galleries.FindAsync(id);
            if (value != null)
                return value;
            return null;
        }

        public async Task UpdateAsync(Gallery gallery)
        {
            _context.Galleries.Update(gallery);
            await _context.SaveChangesAsync();
        }
    }
}
