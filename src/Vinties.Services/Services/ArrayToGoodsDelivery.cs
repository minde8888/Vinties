using System.ComponentModel;
using Vinties.Domain.Helpers;
using Vinties.Domain.Models;
using Vinties.Services.Validators;

namespace Vinties.Services.Services
{
    public class ArrayToGoodsDelivery
    {
        private enum Size
        {
            [Description("S")]
            S,
            [Description("M")]
            M,
            [Description("L")]
            L
        }

        public List<GoodsDelivery> DeliveryList(string[] delivery, string[] prices)
        {
            var prisesDiscounts = PricesList(prices);
            if (prisesDiscounts == null)
                throw new ArgumentException("Prise/discount file is not supported format or empty ");

            var list = new List<GoodsDelivery>();

            foreach (var item in delivery)
            {
                string[] split = item.Split(" ");
                var sizeExist = string.IsNullOrEmpty(split[1].GetEnumValueByDescription<Size>());
                var size = !sizeExist ? split[1].GetEnumValueByDescription<Size>() : null;
                var company = !sizeExist ? split[2] : split[1] + " Ignored";
                var obj = !sizeExist ? prisesDiscounts.Find(x => x.Company == company && x.Size == size) : null;

                list.Add(new GoodsDelivery
                {
                    Date = IsoTime.ParseISO8601String(split[0]),
                    Price = obj?.Price,
                    Discount = obj?.Discount,
                    Size = size,
                    Company = company
                });
            }

            return list;
        }

        private List<PricesDiscounts> PricesList(string[] prices)
        {
            var list = new List<PricesDiscounts>();
            
            foreach (var item in prices)
            {
                string[] split = item.Split(" ");
                
                list.Add(new PricesDiscounts
                {
                    Size = split[0],
                    Company = split[1],
                    Price = Convert.ToDouble(split[2]),
                    Discount = split.Length == 4 ? Convert.ToDouble(split[3]) : null
                });
            }
            return list;
        }
    }
}
