using System.Text.Json.Serialization;

namespace Ecommerce.Models
{
    public class Favourite
    {
        public int Id { get; set; }
        public String UserId { get; set; }
        public User User { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
