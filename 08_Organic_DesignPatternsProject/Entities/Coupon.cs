namespace _08_Organic_DesignPatternsProject.Entities
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public string Code { get; set; }
        public decimal DiscountAmount { get; set; }//indirim miktarı
        public bool IsUsed { get; set; }//kullanılıyor mu
        public DateTime ExpiryDate { get; set; }//son kullanma tarihi
    }
}
