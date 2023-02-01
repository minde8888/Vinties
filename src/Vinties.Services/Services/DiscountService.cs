using Vinties.Domain.Interfaces;
using Vinties.Domain.Models;

namespace Vinties.Services.Services
{
    public class DiscountService
    {
        private readonly ILPDiscountCounter _lPDiscountCounter;
        private readonly IMRDiscount _mRDiscountCounter;

        public DiscountService(
            ILPDiscountCounter lPDiscountCounter,
            IMRDiscount mRDiscountCounter)
        {
            _lPDiscountCounter = lPDiscountCounter;
            _mRDiscountCounter = mRDiscountCounter;
        }
        public List<GoodsDelivery> ApplyDiscounts(List<GoodsDelivery> deliveries, int priceDiscount)
        {
            _lPDiscountCounter.Apply(deliveries);
            _mRDiscountCounter.Apply(deliveries);

            int? month = null;
            double? counterDiscount = 0;

            foreach (var item in deliveries)
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

            return deliveries;
        }
    }
}
