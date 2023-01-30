
using Vinties.Domain.Models;

namespace Vinties.Domain.Interfaces
{
    public interface IMRDiscountCounter
    {
        public List<GoodsDelivery> MRDiscount(List<GoodsDelivery> list);
    }
}
