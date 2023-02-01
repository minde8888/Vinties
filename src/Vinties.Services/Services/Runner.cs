using Vinties.Domain.Interfaces;

namespace Vinties.Services.Services
{
    public class Runner
    {
        private readonly FileService _readTextFile;
        private readonly DiscountService _discountCounter;
        private readonly int maxDiscount = 10;

        public Runner(FileService readTextFile, DiscountService discountCounter)
        {
            _readTextFile = readTextFile;
            _discountCounter = discountCounter;
        }

        public async Task GetDiscountPrices()
        {
            var deliveryList = await _readTextFile.ReadInput();
            var discount = _discountCounter.ApplyDiscounts(deliveryList, maxDiscount);
            _readTextFile.WriteFile(discount);
        }
    }
}
