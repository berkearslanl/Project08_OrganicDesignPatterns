namespace _08_Organic_DesignPatternsProject.Entities
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }//ürün adedi

        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
