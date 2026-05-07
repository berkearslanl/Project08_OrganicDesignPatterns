using _08_Organic_DesignPatternsProject.Observer.Observers;
using _08_Organic_DesignPatternsProject.Services;

namespace _08_Organic_DesignPatternsProject.Observer
{
    public class OrderNotificationService
    {
        private readonly List<IOrderObserver> _observers = new();
        public OrderNotificationService(EmailService emailService)
        {
            // Observer'ları kaydet
            _observers.Add(new OrderConfirmationObserver(emailService));
        }
        // Observer ekle
        public void AddObserver(IOrderObserver observer)
        {
            _observers.Add(observer);
        }
        // Tüm observer'ları tetikle
        public async Task NotifyOrderCreatedAsync(string email, int orderId, decimal totalAmount)
        {
            foreach (var observer in _observers)
            {
                await observer.OnOrderCreatedAsync(email, orderId, totalAmount);
            }
        }
    }
}
