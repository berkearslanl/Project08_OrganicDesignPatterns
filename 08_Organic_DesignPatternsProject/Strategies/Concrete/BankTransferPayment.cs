using _08_Organic_DesignPatternsProject.Strategies.Interfaces;

namespace _08_Organic_DesignPatternsProject.Strategies.Concrete
{
    public class BankTransferPayment : IPaymentStrategy
    {
        public string PaymentMethodName => "EFT / Havale";

        public Task<PaymentResult> ProcessPaymentAsync(PaymentRequest request)
        {
            return Task.FromResult(new PaymentResult
            {
                IsSuccess = true,
                Message = "Havale/EFT talebiniz alındı. Lütfen aşağıdaki IBAN'a ödemenizi yapınız: TR12 3456 7890 1234 5678 9012 34. Ödemeniz onaylandıktan sonra siparişiniz hazırlanacaktır."
            });
        }
    }
}
