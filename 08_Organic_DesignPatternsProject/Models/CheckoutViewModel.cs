using _08_Organic_DesignPatternsProject.Entities;

namespace _08_Organic_DesignPatternsProject.Models
{
    public class CheckoutViewModel
    {
        //müşteri bilgileri
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string Address { get; set; }

        //kupon bilgileri
        public string? CouponCode { get; set; }

        //ödeme yöntemleri
        public string PaymentMethod { get; set; }

        //kredi kartı bilgileri
        public string? CardNumber { get; set; }
        public string? CardHolderName { get; set; }
        public string? ExpiryDate { get; set; }
        public string? CVV { get; set; }

        //sepet özetini göstermek için
        public Cart? Cart { get; set; }

        //hata mesajı
        public string? ErrorMessage { get; set; }
    }
}
