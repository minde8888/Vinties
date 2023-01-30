

using Vinties.Domain.Models;

namespace Vinties.Domain.Interfaces
{
    public interface ILPDiscountCounter
    {
        public List<GoodsDelivery> LPDiscount(List<GoodsDelivery> list);
    }
}
