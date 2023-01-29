
using Vinties.Domain.Models;

namespace Vinties.Services.Discount
{
    public class MRDiscountCounter
    {
        public List<GoodsDelivery> MRDiscount(List<GoodsDelivery> list)
        {
            list.Where(x => x.Company == "MR" && x.Size == "S").Select(s => s.Price -= s.Discount).ToList();
            return list;
        }
    }
}
