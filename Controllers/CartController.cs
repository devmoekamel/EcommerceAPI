using Ecommerce.Context;
using Ecommerce.DTOS;
using Ecommerce.Models;
using Ecommerce.Services.CartService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // POST: api/Cart
        [HttpPost]
        public ActionResult AddItemToCart(CartDTO cartItem)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);  
          var result  =   _cartService.AddItemToCart(cartItem);
            if (result is false) return BadRequest("Something went wrong");
            return Ok ("Product Added To Your Cart");
            
        }

        // DELETE: api/Cart/5
        [HttpDelete("{itemid:int}")]
        public async Task<IActionResult> RemoveItemFromCart(int itemid)
        {
          var result =  _cartService.RemoveItemFromCart(itemid);
            if(result is false) return BadRequest("Something went wrong");
            return Ok("Product Removed from Your Cart");
        }

        // GET: api/Cart/user?userid=
        [HttpGet("user")]
        public ActionResult GetCartItemsForUser([FromQuery]string userId)
        {
          var items =   _cartService.GetCartItemsForUser(userId);
            if(items is null) NotFound("No items found in the user's cart.");
            return Ok(items);

        }
    }
}
