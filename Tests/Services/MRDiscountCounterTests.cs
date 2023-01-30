using AutoFixture.Xunit2;
using Vinties.Domain.Models;
using Vinties.Services.Discount;

namespace Tests.Services
{
    public class MRDiscountCounterTests
    {
        private readonly MRDiscountCounter _mRDiscount;
        public MRDiscountCounterTests()
        {
            _mRDiscount = new MRDiscountCounter();
        }

        [Theory, AutoData]
        public void MRDiscount_GivenDrliveryList_ReturnsResult(List<GoodsDelivery> list)
        {
            //act
            var result = _mRDiscount.MRDiscount(list);

            //result
            Assert.Equal(result, list);
        }
    }
}
