using _08_Organic_DesignPatternsProject.Context;
using _08_Organic_DesignPatternsProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.FeaturedProductRepository
{
    public class FeaturedProductRepository:IFeaturedProductRepository
    {
        private readonly OrganicContext _context;

        public FeaturedProductRepository(OrganicContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(FeaturedProduct featuredProduct)
        {
            await _context.FeaturedProducts.AddAsync(featuredProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _context.FeaturedProducts.FindAsync(id);
            if (value != null)
                _context.FeaturedProducts.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FeaturedProduct>> GetAllAsync()
        {
            var values = await _context.FeaturedProducts.ToListAsync();
            return values;
        }

        public async Task<FeaturedProduct> GetByIdAsync(int id)
        {
            var value = await _context.FeaturedProducts.FindAsync(id);
            if (value != null)
                return value;
            return null;
        }

        public async Task UpdateAsync(FeaturedProduct featuredProduct)
        {
            _context.FeaturedProducts.Update(featuredProduct);
            await _context.SaveChangesAsync();
        }
    }
}
