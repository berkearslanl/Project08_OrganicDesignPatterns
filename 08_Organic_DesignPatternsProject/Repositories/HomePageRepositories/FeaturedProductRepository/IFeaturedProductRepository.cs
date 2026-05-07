using _08_Organic_DesignPatternsProject.Entities;

namespace _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.FeaturedProductRepository
{
    public interface IFeaturedProductRepository
    {
        Task<List<FeaturedProduct>> GetAllAsync();
        Task<FeaturedProduct> GetByIdAsync(int id);
        Task CreateAsync(FeaturedProduct featuredProduct);
        Task UpdateAsync(FeaturedProduct featuredProduct);
        Task DeleteAsync(int id);
    }
}
