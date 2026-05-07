using _08_Organic_DesignPatternsProject.Entities;

namespace _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.SaleBannerRepository
{
    public interface ISaleBannerRepository
    {
        Task<List<SaleBanner>> GetAllAsync();
        Task<SaleBanner> GetByIdAsync(int id);
        Task CreateAsync(SaleBanner saleBanner);
        Task UpdateAsync(SaleBanner saleBanner);
        Task DeleteAsync(int id);
    }
}
