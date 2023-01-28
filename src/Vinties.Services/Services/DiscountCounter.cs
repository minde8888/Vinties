

using Vinties.Domain.Models;

namespace Vinties.Services.Services
{
    public class DiscountCounter
    {
        public List<GoodsDelivery> DiscountRange(List<GoodsDelivery> list)
        {
            int? month = null;
            double? counterDiscount = 0;
            int priceDiscount = 10;

            foreach (var item in list)
            {
                var currentMonth = item.Date.Month;

                if (month != currentMonth)
                {
                    counterDiscount = 0;
                    month = currentMonth;
                }

                if (counterDiscount <= priceDiscount)
                {
                    counterDiscount += item.Discount;
                }
                else
                {
                    item.Discount = null;
                }
            }
            return list;
        }
    }
}
