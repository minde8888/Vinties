using Vinties.Domain.Models;

namespace Vinties.Services.Discount
{
    public class DiscountCounter
    {
        private readonly LPDiscountCounter _lPDiscountCounter;
        private readonly MRDiscountCounter _mRDiscountCounter;

        public DiscountCounter(
            LPDiscountCounter lPDiscountCounter,
            MRDiscountCounter mRDiscountCounter)
        {
            _lPDiscountCounter = lPDiscountCounter;
            _mRDiscountCounter = mRDiscountCounter;
        }
        public List<GoodsDelivery> DiscountRange(List<GoodsDelivery> list, int priceDiscount)
        {
            _ = _lPDiscountCounter.LPDiscount(list);
            _ = _mRDiscountCounter.MRDiscount(list);

            int? month = null;
            double? counterDiscount = 0;

            foreach (var item in list)
            {
                var currentMonth = item.Date.Month;
                if (month != currentMonth)
                {
                    counterDiscount = 0;
                    month = currentMonth;
                }

                if (Math.Round((double)(priceDiscount - counterDiscount), 2) < item.Discount &&
                    item.Discount != null)
                {
                    item.Price -= Math.Round((double)(priceDiscount - counterDiscount), 2);
                    item.Discount = Math.Round((double)(priceDiscount - counterDiscount), 2);
                }

                if (counterDiscount <= priceDiscount &&
                    item.Discount != null &&
                    Math.Round((double)(priceDiscount - counterDiscount), 2) > item.Discount)
                {
                    counterDiscount += item.Discount;
                }
                else if (counterDiscount > priceDiscount)
                {
                    item.Price = item.Discount != null ? item.Price + item.Discount : item.Price;
                    item.Discount = null;
                }
            }

            return list;
        }
    }
}
