using Ecommerce.Context;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services.CouponService
{
    public class CouponService : ICouponService
    {
        private readonly ApplicationDBContext _context;

        public CouponService(ApplicationDBContext Context)
        {
            _context = Context;
        }
        public bool AddCoupon(Coupon coupon)
        {
            _context.Coupons.Add(coupon);
            if (_context.SaveChanges() >= 1) return true;
            else return false;
        }

        public async Task<Coupon> GetCoupon(string name)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.Name == name && c.ExpireDate > DateTime.UtcNow);

            if (coupon == null)
            {
                return null;
            }

            return coupon;
        }

        public bool RemoveCoupon(int id)
        {
            var coupon = _context.Coupons.FirstOrDefault(x=>x.Id==id);
            if (coupon is null)
            {
                return false;
            }

            _context.Coupons.Remove(coupon);
             _context.SaveChanges();
            return true;
        }
    }
}
