

namespace Vinties.Services.Services
{
    public class Discount
    {
        private readonly ReadWriteTextFile _readTextFile;
        private readonly DiscountCounter _discountCounter;

        public Discount(ReadWriteTextFile readTextFile, DiscountCounter discountCounter)
        {
            _readTextFile = readTextFile;
            _discountCounter = discountCounter;
        }

        public async Task GetDiscountPrices()
        {
            var deliveryList = await _readTextFile.ReadFileInput();
            var value = _discountCounter.DiscountRange(deliveryList);

            // deliveryList.Delivery.Where(x => x.Contains("MR") && x.Contains(" S ")).Select(w => { w = "222"; return w; });
        }
    }
}
