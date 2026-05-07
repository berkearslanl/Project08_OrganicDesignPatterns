using _08_Organic_DesignPatternsProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace _08_Organic_DesignPatternsProject.Context
{
    public class OrganicContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-5Q1ARH5E;initial catalog=Project08OrganicDP;integrated security=true;trust server certificate=true");
        }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }

        public DbSet<Banner> Banners { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<FeaturedProduct> FeaturedProducts { get; set; }
        public DbSet<Trend> Trends { get; set; }
        public DbSet<Quality> Qualities { get; set; }
        public DbSet<SaleBanner> SaleBanners { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
    }
}
