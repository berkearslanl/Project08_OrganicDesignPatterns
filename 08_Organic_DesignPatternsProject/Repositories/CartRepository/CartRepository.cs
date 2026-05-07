using _08_Organic_DesignPatternsProject.Context;
using _08_Organic_DesignPatternsProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace _08_Organic_DesignPatternsProject.Repositories.CartRepository
{
    public class CartRepository : ICartRepository
    {
        private readonly OrganicContext _context;

        public CartRepository(OrganicContext context)
        {
            _context = context;
        }

        public async Task AddItemAsync(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task ClearCartAsync(int cartId)
        {
            var values = await _context.CartItems.Where(x => x.CartId == cartId).ToListAsync();
            //foreach (var item in values)
            //{
            //    _context.CartItems.Remove(item);
            //}
            _context.CartItems.RemoveRange(values);//yukarıdaki işlem yerine böyle yaptık. daha performanslı
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetBySessionIdAsync(string sessionId)
        {
            return await _context.Carts
                            .Include(x => x.CartItems)
                                .ThenInclude(y => y.Product)//iç içe ilişki olduğu için (product'a cartitems içeriğinde ulaştık)
                                    .ThenInclude(z=>z.Category)
                                    .FirstOrDefaultAsync(x => x.SessionId == sessionId);
        }

        public async Task RemoveItemAsync(int cartItemId)
        {
            var value = await _context.CartItems.FindAsync(cartItemId);
            _context.CartItems.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task UptadeItemQuantityAsync(int cartItemId, int quantity)
        {
            var value = await _context.CartItems.FindAsync(cartItemId);
            value.Quantity = quantity;
            await _context.SaveChangesAsync();
        }
    }
}
