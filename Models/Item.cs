using System.Text.Json.Serialization;

namespace Ecommerce.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public int Count { get; set; }
        public bool Active { get; set; }
        public int Discount { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
    }
}
