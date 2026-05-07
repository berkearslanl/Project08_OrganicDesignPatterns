using _08_Organic_DesignPatternsProject.Entities;

namespace _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.BannerRepository
{
    public interface IBannerRepository
    {
        Task<List<Banner>> GetAllAsync();
        Task<Banner> GetByIdAsync(int id);
        Task CreateAsync(Banner banner);
        Task UpdateAsync(Banner banner);
        Task DeleteAsync(int id);
    }
}
