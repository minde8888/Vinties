

using Vinties.Services.Discount;

namespace Vinties.Services.Services
{
    public class Discount
    {
        private readonly ReadWriteTextFile _readTextFile;
        private readonly DiscountCounter _discountCounter;
        private int priceDiscount = 10;

        public Discount(ReadWriteTextFile readTextFile, DiscountCounter discountCounter)
        {
            _readTextFile = readTextFile;
            _discountCounter = discountCounter;
        }

        public async Task GetDiscountPrices()
        {
            var deliveryList = await _readTextFile.ReadFileInput();
            var discount = _discountCounter.DiscountRange(deliveryList, priceDiscount);
            _readTextFile.WriteFile(discount);
        }
    }
}
