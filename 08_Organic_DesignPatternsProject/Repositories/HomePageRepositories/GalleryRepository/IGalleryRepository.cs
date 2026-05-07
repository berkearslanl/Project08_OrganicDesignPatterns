using _08_Organic_DesignPatternsProject.Entities;

namespace _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.GalleryRepository
{
    public interface IGalleryRepository
    {
        Task<List<Gallery>> GetAllAsync();
        Task<Gallery> GetByIdAsync(int id);
        Task CreateAsync(Gallery gallery);
        Task UpdateAsync(Gallery gallery);
        Task DeleteAsync(int id);
    }
}
