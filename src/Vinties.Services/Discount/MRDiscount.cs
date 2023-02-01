
using Vinties.Domain.Interfaces;
using Vinties.Domain.Models;

namespace Vinties.Services.Discount
{
    public class MRDiscount : IMRDiscount
    {
        public List<GoodsDelivery> Apply(List<GoodsDelivery> list)
        {
            list.Where(x => x.Company == "MR" && x.Size == "S").ToList().ForEach(s => s.Price -= s.Discount);
            return list;
        }
    }
}
