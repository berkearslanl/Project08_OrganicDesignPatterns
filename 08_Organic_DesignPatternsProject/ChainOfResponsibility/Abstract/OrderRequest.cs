using _08_Organic_DesignPatternsProject.Entities;

namespace _08_Organic_DesignPatternsProject.ChainOfResponsibility.Abstract
{
    public class OrderRequest
    {
        //zincirde ihtiyaç duyulan ögeler

        public List<CartItem> CartItems { get; set; }
        public string CouponCode { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
