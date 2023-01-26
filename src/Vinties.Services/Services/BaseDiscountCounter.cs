using Vinties.Domain.Models;

namespace Vinties.Services.Services
{
    public abstract class BaseDiscountCounter
    {
        private readonly BaseSizes _baseDiscount;
        public BaseDiscountCounter(BaseSizes baseDiscount)
        {
            _baseDiscount = baseDiscount;
        }
        public abstract string[] GetDiscount(string[] file);
    }
}
