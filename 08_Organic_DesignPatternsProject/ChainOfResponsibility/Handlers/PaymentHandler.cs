using _08_Organic_DesignPatternsProject.ChainOfResponsibility.Abstract;
using _08_Organic_DesignPatternsProject.Enums;

namespace _08_Organic_DesignPatternsProject.ChainOfResponsibility.Handlers
{
    public class PaymentHandler : OrderHandler
    {
        public override async Task<string> Handle(OrderRequest request)
        {
            var validPaymentMethods = new List<string>//mevcuttaki ödeme yöntemlerini bir listeue çektik
            {
                PaymentMethod.CreditCard.ToString(),//request'teki method string olduğu için dönüşüm
                PaymentMethod.BankTransfer.ToString(),
                PaymentMethod.CashOnDelivery.ToString()
            };

            if (!validPaymentMethods.Contains(request.PaymentMethod))//bu liste kullanıcıdan girilen ödeme methodunu içermiyorsa
            {
                return "Geçersiz ödeme yöntemi seçildi.";
            }
            if (_nextHandler != null)
            {
                return await _nextHandler.Handle(request);
            }
            return null;
        }
    }
}
