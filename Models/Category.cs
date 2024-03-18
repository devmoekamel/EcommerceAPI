using System.Text.Json.Serialization;

namespace Ecommerce.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [JsonIgnore]
        public ICollection<Item>? Items { get; set; }
    }
}
