using Vinties.Services.Services;

namespace Tests.Services
{
    public class ArrayToGoodsDeliveryTests
    {
        private readonly DateConvertServices _arrayToGoodsDelivery;
        public ArrayToGoodsDeliveryTests()
        {
            _arrayToGoodsDelivery = new DateConvertServices();
        }

        [Fact]
        public void DeliveryList()
        {
            string[] delivery = new string[] { "2015-02-01 S MR" };
            string[] prices = new string[] { "S MR 2 0,5" };

            //act 
            var result = _arrayToGoodsDelivery.ConvertToDeliverys(delivery, prices);
            //result
            Assert.NotNull(result);
        }

    }
}
