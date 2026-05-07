using _08_Organic_DesignPatternsProject.Context;
using _08_Organic_DesignPatternsProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace _08_Organic_DesignPatternsProject.Repositories.SubscriberRepository
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly OrganicContext _context;

        public SubscriberRepository(OrganicContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Subscriber subscriber)
        {
            await _context.Subscribers.AddAsync(subscriber);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Subscriber>> GetAllAsync()
        {
            return await _context.Subscribers.ToListAsync();
        }

        public async Task<bool> IsEmailExistAsync(string email)
        {
            return await _context.Subscribers.AnyAsync(x => x.Email == email);//veri var mı yok mu(evet hayır döner)
        }
    }
}
