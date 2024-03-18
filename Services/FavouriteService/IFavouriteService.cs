using Ecommerce.DTOS;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Services.FavouriteService
{
    public interface IFavouriteService
    {
        bool AddFavourite(FavDTO favourite);
        bool RemoveFavourite(int id);
        Task<IEnumerable<Item>> GetFavouriteProductsForUser(string userId);
    }
}
