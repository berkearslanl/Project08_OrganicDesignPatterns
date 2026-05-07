using _08_Organic_DesignPatternsProject.Context;
using _08_Organic_DesignPatternsProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace _08_Organic_DesignPatternsProject.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrganicContext _context;

        public ProductRepository(OrganicContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _context.Products.FindAsync(id);
            _context.Products.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(y => y.ProductId == id);
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Product>> GetFilteredAsync(int? categoryId, decimal? minPrice, decimal? maxPrice, bool? isOrganic)
        {
            var values = _context.Products.Include(x => x.Category).AsQueryable();

            if (categoryId.HasValue)//category inputu seçilmişse
            {
                values = values.Where(x => x.CategoryId == categoryId.Value);
            }
            if (minPrice.HasValue)
            {
                values = values.Where(x => x.Price >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                values = values.Where(x => x.Price <= maxPrice.Value);
            }
            if (isOrganic.HasValue)
            {
                values = values.Where(x => x.IsOrganic == isOrganic.Value);
            }

            return await values.ToListAsync();
        }

        public async Task<List<Product>> GetLast4ProductAsync()
        {
            return await _context.Products.Include(x=>x.Category).OrderByDescending(x => x.ProductId).Take(4).ToListAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
