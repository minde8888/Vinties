using Vinties.Domain.Interfaces;
using Vinties.Domain.Models;

namespace Vinties.Services.Discount
{
    public class LPDiscountCounter: ILPDiscountCounter
    {
        public List<GoodsDelivery> LPDiscount(List<GoodsDelivery> list)
        {
            var couner = 0;
            int? month = null;
            var onesMonth = true;

            foreach (var item in list.Where(x => x.Company == "LP" && x.Size == "L"))
            {
                couner++;

                var currentMonth = item.Date.Month;
                if (month != currentMonth)
                {
                    month = currentMonth;
                    onesMonth = true;
                }
               
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
