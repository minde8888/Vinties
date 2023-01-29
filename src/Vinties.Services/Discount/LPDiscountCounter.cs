using Vinties.Domain.Models;

namespace Vinties.Services.Discount
{
    public class LPDiscountCounter
    {
        public List<GoodsDelivery> LPDiscount(List<GoodsDelivery> list)
        {
            var couner = 0;
            int? month = null;
            var onesMonth = true;

            foreach (var item in list.Where(x => x.Company == "LP" && x.Size == "L"))
            {
                var currentMonth = item.Date.Month;
                if (month != currentMonth)
                {
                    month = currentMonth;
                    onesMonth = true;
                }
                couner++;
                if (couner % 3 == 0 && onesMonth)
                {
                    item.Price -= item.Discount;
                    onesMonth = false;
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
