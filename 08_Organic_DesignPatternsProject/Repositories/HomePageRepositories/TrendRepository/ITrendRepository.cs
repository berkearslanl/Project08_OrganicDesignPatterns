using _08_Organic_DesignPatternsProject.Entities;

namespace _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.TrendRepository
{
    public interface ITrendRepository
    {
        Task<List<Trend>> GetAllAsync();
        Task<Trend> GetByIdAsync(int id);
        Task CreateAsync(Trend trend);
        Task UpdateAsync(Trend trend);
        Task DeleteAsync(int id);
    }
}
