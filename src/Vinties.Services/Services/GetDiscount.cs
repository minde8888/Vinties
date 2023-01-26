using Vinties.Domain.Helpers;

namespace Vinties.Services.Services
{
    public class GetDiscount
    {
        public string[] DiscountByDate(string[] text)
        {
            double counterDiscount = 0;
            int priceDiscount = 10;
            int? month = null;
            double priceMR = 2;
            double discountMR = 0.50;
            double priceLP = 6.9;
            double discountLP = 6.9;
            bool monthLP = true;

            foreach (var item in text)
            {
                var date = IsoTime.ParseISO8601String(item.Substring(0, 10));

                var currentMonth = date.Month;

                if (month != currentMonth)
                {
                    counterDiscount = 0;
                    month = currentMonth;
                }

                double discount = priceDiscount - counterDiscount;
                string[] split = item.Split(" ");
                var size = split[1];
                var company = split[2];

                if (company == "MR" && size == "S" && discount >= discountMR)
                {
                    counterDiscount += discountMR;
                    var line = item.Substring(0, item.LastIndexOf(' ')).TrimEnd();
                    var index = Array.IndexOf(text, item);
                    text[index] = line + $" {priceMR - discountMR} {discountMR}";
                }
                else if (company == "MR" &&
                    size == "S" &&
                    discount > 0 &&
                    discount < discountMR)
                {
                    var line = item.Substring(0, item.LastIndexOf(' ')).TrimEnd();
                    var index = Array.IndexOf(text, item);
                    text[index] = line + $" {Math.Round(priceMR - discount, 2)} {Math.Round(discount, 2)}";
                    counterDiscount = priceDiscount;
                }

                if (company == "LP" &&
                    size == "L" &&
                   discount >= discountLP &&
                   monthLP)
                {
                    counterDiscount += discountLP;
                    var line = item.Substring(0, item.LastIndexOf(' ')).TrimEnd();

                    var index = Array.IndexOf(text, item);
                    text[index] = line + $" {priceLP - discountLP} {discountLP}";
                    monthLP = false;
                }
            }

            return text;
        }
    }
}
