using Vinties.Services.Discount;

namespace Vinties.Services.Services
{
    public class ExecuteDiscount
    {
        private readonly ReadWriteTextFile _readTextFile;
        private readonly DiscountCounter _discountCounter;
        private readonly int maxDiscount = 10;

        public ExecuteDiscount(ReadWriteTextFile readTextFile, DiscountCounter discountCounter)
        {
            _readTextFile = readTextFile;
            _discountCounter = discountCounter;
        }

        public async Task GetDiscountPrices()
        {
            var deliveryList = await _readTextFile.ReadFileInput();
            var discount = _discountCounter.DiscountRange(deliveryList, maxDiscount);
            _readTextFile.WriteFile(discount);
        }
    }
}
