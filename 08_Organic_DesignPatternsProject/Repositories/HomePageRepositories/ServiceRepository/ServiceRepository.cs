using _08_Organic_DesignPatternsProject.Context;
using _08_Organic_DesignPatternsProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly OrganicContext _context;

        public ServiceRepository(OrganicContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Service service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _context.Services.FindAsync(id);
            if (value != null)
                _context.Services.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Service>> GetAllAsync()
        {
            var values = await _context.Services.ToListAsync();
            return values;
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            var value = await _context.Services.FindAsync(id);
            if (value != null)
                return value;
            return null;
        }

        public async Task UpdateAsync(Service service)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
        }
    }
}
