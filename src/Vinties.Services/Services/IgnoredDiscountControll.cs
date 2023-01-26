using Vinties.Domain.Helpers;
using Vinties.Domain.Models;

namespace Vinties.Services.Services
{
    public class IgnoredDiscountControll : BaseDiscountCounter
    {
        public IgnoredDiscountControll(BaseSizes price) : base(price)
        {
        }
        public override string[] GetDiscount(string[] text)
        {
            foreach (var item in text)
            {
                if (!(item.Contains("MR") || item.Contains("LP")))
                {
                    var index = Array.IndexOf(text, item);
                    text[index] = item + " Ignored";
                }
            }

            return text;
        }
    }
}
