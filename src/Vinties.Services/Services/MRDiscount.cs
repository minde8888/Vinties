

using Vinties.Domain.Models;

namespace Vinties.Services.Services
{
    public class MRDiscount : BaseDiscountCounter
    {
        public MRDiscount(BaseSizes price) : base(price)
        {
        }
        public override string[] GetDiscount(string[] text)
        {
            foreach (var item in text)
            {
                if (item.Contains("MR") && item.Contains(" S "))
                {
                    var index = Array.IndexOf(text, item);
                    text[index] = item + " 2";
                }
                else if (item.Contains("MR") && item.Contains(" M "))
                {
                    var index = Array.IndexOf(text, item);
                    text[index] = item + " 3";
                }
                else if (item.Contains("MR") && item.Contains(" L "))
                {
                    var index = Array.IndexOf(text, item);
                    text[index] = item + " 4";
                }
            }

            return text;
        }
    }
}
