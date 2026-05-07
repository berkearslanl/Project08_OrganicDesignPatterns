using _08_Organic_DesignPatternsProject.Entities;

namespace _08_Organic_DesignPatternsProject.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetFilteredAsync(int? categoryId,decimal? minPrice, decimal? maxPrice, bool? isOrganic); // ürün listesi sayfasında filteelme işlemi
        Task<Product> GetByIdAsync(int id);
        Task<List<Category>> GetCategoriesAsync();
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);

        Task<List<Product>> GetLast4ProductAsync();
    }
}
