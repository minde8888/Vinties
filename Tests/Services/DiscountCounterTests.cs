using AutoFixture.Xunit2;
using Moq;
using System.Collections.Generic;
using Vinties.Domain.Interfaces;
using Vinties.Domain.Models;
using Vinties.Services.Discount;

namespace Tests.Services
{
    public class DiscountCounterTests
    {
        private readonly Mock<ILPDiscountCounter> _lPDscountCounter;
        private readonly Mock<IMRDiscountCounter> _mRDscountCounter;
        private readonly DiscountCounter _discountCounter;

        public DiscountCounterTests()
        {
            _lPDscountCounter = new Mock<ILPDiscountCounter>();
            _mRDscountCounter = new Mock<IMRDiscountCounter>();
            _discountCounter = new DiscountCounter(_lPDscountCounter.Object, _mRDscountCounter.Object);
        }
        [Theory, AutoData]
        public void DiscountCounter_GivenDrliveryList_ReturnsResult(List<GoodsDelivery> list)
        {
            // arrange
            _lPDscountCounter.Setup(x => x.LPDiscount(list)).Returns(list);
            _mRDscountCounter.Setup(x => x.MRDiscount(list)).Returns(list);
            //act
            var result = _discountCounter.DiscountRange(list, 10);
            //result
            Assert.Equal(result, list);

        }
    }
}
