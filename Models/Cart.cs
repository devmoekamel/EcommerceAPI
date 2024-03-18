using System.Text.Json.Serialization;

namespace Ecommerce.Models
{
    public class Cart
    {
        public int Id { get; set; }
       
        public String UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int ItemId { get; set; }
        [JsonIgnore]
        public Item Item { get; set; }
    }

}
