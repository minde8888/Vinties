using Vinties.Domain.Models;

namespace Vinties.Services.Services
{
    public abstract class BaseDiscountCounter
    {
        private readonly BaseDiscount _baseDiscount;
        public BaseDiscountCounter(BaseDiscount baseDiscount)
        {
            _baseDiscount = baseDiscount;
        }
        public abstract string[] GetDiscount(string[] text);
    }
}
