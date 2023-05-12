using ShoppingWebApi.EfCore;

namespace ShoppingWebApi.Models
{
    public class OrderModel
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public string name { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
