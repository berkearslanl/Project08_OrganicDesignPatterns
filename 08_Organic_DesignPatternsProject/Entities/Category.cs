namespace _08_Organic_DesignPatternsProject.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
