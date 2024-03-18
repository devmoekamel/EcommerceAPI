using Ecommerce.Context;
using Ecommerce.DTOS;
using Ecommerce.Models;
using Ecommerce.Services.FavouriteService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
       private readonly IFavouriteService _favouriteservice;

        public FavouriteController(IFavouriteService favouriteservice)
        {
            _favouriteservice = favouriteservice;
        }

        // POST: api/Favourite
        [HttpPost]
        public  ActionResult AddFavourite(FavDTO favourite)
        {
            if (!ModelState.IsValid)
                return BadRequest("UserID and ItemID ar Required");
            var  result  =_favouriteservice.AddFavourite(favourite);
            if(result is not true) return BadRequest("Something went wrong");
            return Ok("Product Added");
          }

        // DELETE: api/Favourite/5
        [HttpDelete("{id:int}")]
        public IActionResult RemoveFavourite(int id)
        {
           var result = _favouriteservice.RemoveFavourite(id);
            if(result is not true) return BadRequest("Something went wrong");
            return Ok("Product Removed");
        }

        // GET: api/Favourite/user/5
        [HttpGet("user")]
        public async Task<ActionResult> GetFavouriteProductsForUser([FromQuery]string userId)
        {
            var Products = await _favouriteservice.GetFavouriteProductsForUser(userId);
            if(Products is  null) return NotFound("No items found in the user's cart.");
            return Ok(Products);
        }
    }
}
