namespace _08_Organic_DesignPatternsProject.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public string SessionId { get; set; }//kullanıcı siteye girine ona otomatik id verilir. sepetin kime ait olduğu belli olsun diye
        public DateTime CareatedAt { get; set; }//sepet ne zaman oluşturuldu

        public List<CartItem> CartItems { get; set; }
    }
}
