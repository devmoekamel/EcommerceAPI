using Ecommerce.Context;
using Ecommerce.DTOS;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ApplicationDBContext _context;
        public CartService(ApplicationDBContext context)
        {
            _context = context;
        }
        public bool AddItemToCart(CartDTO cartItem)
        {

            var item = new Cart
            {
                ItemId = cartItem.ItemId,
                UserId = cartItem.UserId,
            };
            _context.Carts.Add(item);

            if (_context.SaveChanges() >= 1) return true;
              return false;
          
        }

        public IEnumerable<Item> GetCartItemsForUser(string userId)
        {
            var cartItems =  _context.Carts
               .Where(c => c.UserId == userId)
               .Include(c => c.Item)
               .Select(c => c.Item)
               .ToList();

            if (cartItems == null || !cartItems.Any())
            {
                return null;
            }

            return cartItems;
        }

        public bool RemoveItemFromCart(int itemid)
        {
            var cartItem = _context.Carts.FirstOrDefault(c => c.ItemId == itemid);
            if (cartItem == null)
            {
                return false;
            }

            _context.Carts.Remove(cartItem);
            _context.SaveChanges();

            return true;
        }
    }
}
