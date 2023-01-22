using Vinties.Domain.Helpers;
using Vinties.Domain.Models;

namespace Vinties.Services.Services
{
    public class Discount
    {
        private readonly LPDiscount _lpDiscountCounter;
        private readonly MRDiscount _mrDiscountCounter;
        private readonly IgnoredDiscountControll _ignoredDiscount;
        private readonly ReadTextFileService _readTextFile;
        private readonly GetDiscount _getDiscount;

        public Discount(
            LPDiscount lpDiscountCounter,
            MRDiscount mrDiscountCounter,
            IgnoredDiscountControll ignoredDiscount,
            ReadTextFileService readTextFile,
            GetDiscount getDiscount)
        {
            _lpDiscountCounter = lpDiscountCounter;
            _mrDiscountCounter = mrDiscountCounter;
            _ignoredDiscount = ignoredDiscount;
            _readTextFile = readTextFile;
            _getDiscount = getDiscount;
        }

        public async Task LPDPrices()
        {
            var text = await _readTextFile.GetText();

            var lpPrices = _lpDiscountCounter.GetDiscount(text);
            var mrPrices = _mrDiscountCounter.GetDiscount(lpPrices);
            var ignored = _ignoredDiscount.GetDiscount(mrPrices);
            var result = _getDiscount.DiscountByDate(ignored);

            Domain.Helpers.StreamWriter.WriteLine(result);
        }
    }
}
