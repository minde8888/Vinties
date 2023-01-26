

using System.Security.Cryptography.X509Certificates;

namespace Vinties.Services.Services
{
    public class Discount
    {
        //private readonly LPDiscount _lpDiscountCounter;
        //private readonly MRDiscount _mrDiscountCounter;
        //private readonly IgnoredDiscountControll _ignoredDiscount;
        private readonly ReadTextFileService _readTextFile;
        //private readonly GetDiscount _getDiscount;

        public Discount(
            //LPDiscount lpDiscountCounter,
            //MRDiscount mrDiscountCounter,
            //IgnoredDiscountControll ignoredDiscount,
            ReadTextFileService readTextFile
            //GetDiscount getDiscount
            )
        {
            //_lpDiscountCounter = lpDiscountCounter;
            //_mrDiscountCounter = mrDiscountCounter;
            //_ignoredDiscount = ignoredDiscount;
            _readTextFile = readTextFile;
            //_getDiscount = getDiscount;
        }

        public async Task GetDiscountPrices()
        {
            var deliveryList = await _readTextFile.GetInput();
            //var b = deliveryList.Delivery.Where(x => x.Contains("MR") && x.Contains(" S ")).ToList();
           // deliveryList.Delivery.Where(x => x.Contains("MR") && x.Contains(" S ")).Select(w => { w = "222"; return w; });
            var a = deliveryList;
            //var lpPrices = _lpDiscountCounter.GetDiscount(text);
            //var mrPrices = _mrDiscountCounter.GetDiscount(lpPrices);
            //var ignored = _ignoredDiscount.GetDiscount(mrPrices);
            //var result = _getDiscount.DiscountByDate(ignored);

            //Domain.Helpers.StreamWriter.WriteLine(result);
            //.Split(" ")
        }
    }
}
