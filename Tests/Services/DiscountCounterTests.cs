using AutoFixture.Xunit2;
using Moq;
using Vinties.Domain.Interfaces;
using Vinties.Domain.Models;
using Vinties.Services.Services;

namespace Tests.Services
{
    public class DiscountCounterTests
    {
        private readonly DiscountService _discountCounter;

        public DiscountCounterTests()
        {
            //_discountCounter = new DiscountService();
        }
        [Theory, AutoData]
        public void DiscountCounter_GivenDrliveryList_ReturnsResult(List<GoodsDelivery> list)
        {
            //act
            var result = _discountCounter.ApplyDiscounts(list, 10);
            //result
            Assert.Equal(result, list);

        }
    }
}
