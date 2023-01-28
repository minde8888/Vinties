
namespace Vinties.Domain.Models
{
    public class GoodsDelivery 
    {
        public DateTime Date { get; set; }
        public double? Price { get; set; }
        public double? Discount { get; set; } 
        public string Company { get; set; }
        public string Size { get; set; }
    }
}
