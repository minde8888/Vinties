

using Vinties.Domain.Models;

namespace Vinties.Domain.Interfaces
{
    public interface ILPDiscountCounter
    {
        public void Apply(List<GoodsDelivery> list);
    }
}
