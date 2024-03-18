using Ecommerce.DTOS;
using Ecommerce.Models;

namespace Ecommerce.Services.CartService
{
    public interface ICartService
    {
        bool AddItemToCart(CartDTO cartItem);
        bool RemoveItemFromCart(int id);
        IEnumerable<Item> GetCartItemsForUser(string userId);
    }
}
