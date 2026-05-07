using _08_Organic_DesignPatternsProject.Entities;

namespace _08_Organic_DesignPatternsProject.Repositories.CartRepository
{
    public interface ICartRepository
    {
        Task<Cart> GetBySessionIdAsync(string sessionId);//siteye giriş yapan kullanıcıya ait sepeti getir
        Task CreateAsync(Cart cart);//kullanıcı sepete ürün eklediğinde yeni sepet oluşturur
        Task AddItemAsync(CartItem cartItem);//sepete yeni ürün ekleme
        Task UptadeItemQuantityAsync(int cartItemId, int quantity);//sepet sayfasında ürün adedini değiştirir
        Task RemoveItemAsync(int cartItemId);//sepetten bir ürün kaldır
        Task ClearCartAsync(int cartId);//sepet temizle
    }
}
