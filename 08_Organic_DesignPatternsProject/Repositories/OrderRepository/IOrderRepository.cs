using _08_Organic_DesignPatternsProject.Entities;

namespace _08_Organic_DesignPatternsProject.Repositories.OrderRepository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task CreateAsync(Order order);
        Task UpdateStatusAsync(int id, string status);
    }
}
