using _08_Organic_DesignPatternsProject.Enums;

namespace _08_Organic_DesignPatternsProject.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string Address { get; set; }
        public decimal TotalAmount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }//enum
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? CouponId { get; set; }//kupon kodu zorunlu değil
        public Coupon Coupon { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
