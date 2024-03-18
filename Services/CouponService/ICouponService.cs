using Ecommerce.Models;

namespace Ecommerce.Services.CouponService
{
    public interface ICouponService
    {
        bool AddCoupon (Coupon coupon);
        bool RemoveCoupon(int id);
        Task<Coupon> GetCoupon(string name);
    }
}
