using Ecommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Context
{
    public class ApplicationDBContext :IdentityDbContext<User>
    {
       
        public ApplicationDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
