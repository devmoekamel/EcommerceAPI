using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
    }

}
