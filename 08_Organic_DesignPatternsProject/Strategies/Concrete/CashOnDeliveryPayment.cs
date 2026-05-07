using _08_Organic_DesignPatternsProject.Strategies.Interfaces;

namespace _08_Organic_DesignPatternsProject.Strategies.Concrete
{
    public class CashOnDeliveryPayment : IPaymentStrategy
    {
        public string PaymentMethodName => "Kapıda Ödeme";

        public Task<PaymentResult> ProcessPaymentAsync(PaymentRequest request)
        {
            return Task.FromResult(new PaymentResult
            {
                IsSuccess = true,
                Message = "Siparişiniz alındı. Ödeme kapıda tahsil edilecektir."
            });
        }
    }
}
