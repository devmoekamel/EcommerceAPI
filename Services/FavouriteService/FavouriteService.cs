using Ecommerce.Context;
using Ecommerce.DTOS;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services.FavouriteService
{
    public class FavouriteService : IFavouriteService
    {
        private readonly ApplicationDBContext _context;

        public FavouriteService(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool AddFavourite(FavDTO favourite)
        {
            var fav = new Favourite
            {
                UserId = favourite.UserId,
                ItemId = favourite.ItemId,
            };
            _context.Favourites.Add(fav);
            if (_context.SaveChanges() >= 1) return true;
            return false;
        }

        public async Task<IEnumerable<Item>> GetFavouriteProductsForUser(string userId)
        {
            var favouriteProducts = await _context.Favourites
               .Where(f => f.UserId == userId)
               .Include(f => f.Item)
               .Select(f => f.Item)
               .ToListAsync();

            if (favouriteProducts == null || !favouriteProducts.Any())
            {
                return null;
            }

            return favouriteProducts;
        }

        public bool RemoveFavourite(int id)
        {
            var favourite =  _context.Favourites.Find(id);
            if (favourite == null)
            {
                return false;
            }

            _context.Favourites.Remove(favourite);
             _context.SaveChanges();

            return true;
        }
    }
}
