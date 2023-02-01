
using Vinties.Domain.Models;

namespace Vinties.Domain.Interfaces
{
    public interface IMRDiscount
    {
        public List<GoodsDelivery> Apply(List<GoodsDelivery> list);
    }
}
