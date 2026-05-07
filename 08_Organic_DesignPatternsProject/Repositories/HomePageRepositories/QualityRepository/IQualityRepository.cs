using _08_Organic_DesignPatternsProject.Entities;

namespace _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.QualityRepository
{
    public interface IQualityRepository
    {
        Task<Quality> GetAllAsync();
        Task<Quality> GetByIdAsync(int id);
        Task CreateAsync(Quality quality);
        Task UpdateAsync(Quality quality);
        Task DeleteAsync(int id);
    }
}
