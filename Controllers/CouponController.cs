using Ecommerce.Context;
using Ecommerce.Models;
using Ecommerce.Services.CouponService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
 //       private readonly ApplicationDBContext _context;
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
 
            this._couponService = couponService;
        }

        // POST: api/Coupon
        [HttpPost]
        public async Task<ActionResult> AddCoupon(Coupon coupon)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var result  = _couponService.AddCoupon(coupon);

            if(!result) return BadRequest("Somthing went Wrong ");
            return Ok("Coupon is Created ");
        }

        // DELETE: api/Coupon/5
        [HttpDelete("{id:int}")]
        public  IActionResult RemoveCoupon(int id)
        {
            var result = _couponService.RemoveCoupon(id);
            if (!result) return BadRequest("Somthing went Wrong ");

            return Ok("Coupon Deleted Successfully ");
        }

        // GET: api/Coupon/{name}
        [HttpGet("{name}")]
        public async Task<ActionResult<Coupon>> GetCoupon(string name)
        {
            var result  = await _couponService.GetCoupon(name);
            if (result is null) return BadRequest("Coupon is invalid or doesn't exist");
            return Ok(result);
        }
    }
}
