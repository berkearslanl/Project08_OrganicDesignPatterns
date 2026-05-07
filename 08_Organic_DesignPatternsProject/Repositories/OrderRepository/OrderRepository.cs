using _08_Organic_DesignPatternsProject.Context;
using _08_Organic_DesignPatternsProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace _08_Organic_DesignPatternsProject.Repositories.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrganicContext _context;

        public OrderRepository(OrganicContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.Include(x => x.OrderItems)
                                            .ThenInclude(y => y.Product)
                                        .Include(x => x.Coupon)
                                        .OrderByDescending(x => x.CreatedAt)
                                        .ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders.Include(x => x.OrderItems)
                                            .ThenInclude(y => y.Product)
                                        .Include(x => x.Coupon)
                                        .FirstOrDefaultAsync(x => x.OrderId == id);
        }

        public async Task UpdateStatusAsync(int id, string status)
        {
            var value = await _context.Orders.FindAsync(id);
            value.Status = status;
            await _context.SaveChangesAsync();
        }
    }
}
