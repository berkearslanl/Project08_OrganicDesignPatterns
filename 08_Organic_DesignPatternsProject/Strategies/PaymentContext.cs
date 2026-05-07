using _08_Organic_DesignPatternsProject.Strategies.Interfaces;

namespace _08_Organic_DesignPatternsProject.Strategies
{
    public class PaymentContext
    {
        private IPaymentStrategy _paymentStrategy;

        public void SetStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }
        public async Task<PaymentResult> ExecutePaymentAsync(PaymentRequest request)
        {
            if (_paymentStrategy == null)
                throw new InvalidOperationException("Ödeme yöntemi seçilmedi.");

            return await _paymentStrategy.ProcessPaymentAsync(request);
        }
    }
}
