using _08_Organic_DesignPatternsProject.Entities;

namespace _08_Organic_DesignPatternsProject.Repositories.SubscriberRepository
{
    public interface ISubscriberRepository
    {
        Task<List<Subscriber>> GetAllAsync();
        Task AddAsync(Subscriber subscriber);
        Task<bool> IsEmailExistAsync(string email);//aynı email varmı onu kontrol eder
    }
}
