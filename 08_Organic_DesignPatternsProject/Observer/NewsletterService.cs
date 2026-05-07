using _08_Organic_DesignPatternsProject.Entities;
using _08_Organic_DesignPatternsProject.Observer.Observers;
using _08_Organic_DesignPatternsProject.Repositories.SubscriberRepository;
using _08_Organic_DesignPatternsProject.Services;

namespace _08_Organic_DesignPatternsProject.Observer
{
    public class NewsletterService
    {
        private readonly List<ISubscriberObserver> _observers = new();
        private readonly ISubscriberRepository _subscriberRepository;

        public NewsletterService(ISubscriberRepository subscriberRepository, EmailService emailService)
        {
            _subscriberRepository = subscriberRepository;

            _observers.Add(new WelcomeEmailObserver(emailService));
        }
        //observer ekle
        public void AddObserver(ISubscriberObserver observer)
        {
            _observers.Add(observer);
        }

        public async Task SubscribeAsync(string email)
        {
            //zaten email kayıtlıysa işlem yapma
            if (await _subscriberRepository.IsEmailExistAsync(email))
                return;
            //veritabanına kaydet
            var subscriber = new Subscriber
            {
                Email = email,
                SubscribedAt = DateTime.Now
            };
            await _subscriberRepository.AddAsync(subscriber);

            //observer'ları tetikle
            foreach (var observer in _observers)
            {
                await observer.OnSubscribedAsync(email);
            }
        }
    }
}
