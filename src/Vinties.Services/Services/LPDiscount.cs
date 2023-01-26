using Vinties.Domain.Models;

namespace Vinties.Services.Services
{
    public class LPDiscount : BaseDiscountCounter
    {
        public LPDiscount(BaseSizes price) : base(price)
        {
        }
        public override string[] GetDiscount(string[] text)
        {
            foreach (var item in text)
            {
                if (item.Contains("LP") && item.Contains(" S "))
                {
                    var index = Array.IndexOf(text, item); ;
                    text[index] = item + " 1.5";
                }
                else if (item.Contains("LP") && item.Contains(" M "))
                {
                    var index = Array.IndexOf(text, item);
                    text[index] = item + " 4.9";
                }
                else if (item.Contains("LP") && item.Contains(" L "))
                {
                    var index = Array.IndexOf(text, item);
                    text[index] = item + " 6.9";
                }
            }

            return text;
        }
    }
}
