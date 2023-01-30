using AutoFixture.Xunit2;
using System.Collections.Generic;
using Vinties.Domain.Models;
using Vinties.Services.Discount;

namespace Tests.Services
{
    public class LPDiscountCounterTests
    {
        private readonly LPDiscountCounter _lPDiscount;
        public LPDiscountCounterTests()
        {
            _lPDiscount = new LPDiscountCounter();
        }

        [Theory, AutoData]
        public void LPDiscount_GivenDrliveryList_ReturnsResult(List<GoodsDelivery> list)
        {
            //act
            var result = _lPDiscount.LPDiscount(list);

            //result
            Assert.Equal(result, list);
        }
    }
}
