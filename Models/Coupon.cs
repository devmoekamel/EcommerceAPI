namespace Ecommerce.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Discount { get; set; }
        public DateTime ExpireDate { get; set; }  = DateTime.Now.AddDays(10);
    }
}
