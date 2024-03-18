using System.ComponentModel.DataAnnotations;

namespace Ecommerce.DTOS
{
    public class RegisterDTO
    {
        [StringLength(70)]
        public string FirstName { get; set; }
        [StringLength(70)]

        public string LastName { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
