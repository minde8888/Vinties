using Vinties.Services.Services;

namespace Tests.Services
{
    public class ArrayToGoodsDeliveryTests
    {
        private readonly ArrayToGoodsDelivery _arrayToGoodsDelivery;
        public ArrayToGoodsDeliveryTests()
        {
            _arrayToGoodsDelivery = new ArrayToGoodsDelivery();
        }

        [Fact]
        public void DeliveryList()
        {
            string[] delivery = new string[] { "2015-02-01 S MR" };
            string[] prices = new string[] { "S MR 2 0,5" };

            //act 
            var result = _arrayToGoodsDelivery.DeliveryList(delivery, prices);
            //result
            Assert.NotNull(result);
        }

    }
}
