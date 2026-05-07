using _08_Organic_DesignPatternsProject.Entities;

namespace _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetAllAsync();
        Task<Service> GetByIdAsync(int id);
        Task CreateAsync(Service service);
        Task UpdateAsync(Service service);
        Task DeleteAsync(int id);   
    }
}
