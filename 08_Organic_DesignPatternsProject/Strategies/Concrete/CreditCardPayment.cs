using _08_Organic_DesignPatternsProject.Strategies.Interfaces;

namespace _08_Organic_DesignPatternsProject.Strategies.Concrete
{
    public class CreditCardPayment : IPaymentStrategy
    {
        public string PaymentMethodName => "Kredi Kartı";

        public Task<PaymentResult> ProcessPaymentAsync(PaymentRequest request)
        {
            if (string.IsNullOrEmpty(request.CardNumber) ||
               string.IsNullOrEmpty(request.CardHolderName) ||
               string.IsNullOrEmpty(request.ExpiryDate) ||
               string.IsNullOrEmpty(request.CVV))
            {
                return Task.FromResult(new PaymentResult
                {
                    IsSuccess = false,
                    Message = "Kart bilgileri eksik veya hatalı."
                });
            }

            return Task.FromResult(new PaymentResult
            {
                IsSuccess = true,
                Message = "Kredi kartı ödemesi başarıyla tamamalandı."
            });
        }
    }
}
