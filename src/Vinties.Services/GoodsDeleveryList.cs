
using System.ComponentModel;
using Vinties.Domain.Helpers;
using Vinties.Domain.Models;
using Vinties.Services.Validators;

namespace Vinties.Services
{
    public class GoodsDeleveryList
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

        public List<GoodsDelivery> DeliveryList(string[] delivery)
        {
            var list = new List<GoodsDelivery>();

            foreach (var item in delivery)
            {
                string[] split = item.Split(" ");
                var size = !String.IsNullOrEmpty(EnumValidator.GetEnumValueByDescription<Size>(split[1]));
                list.Add(new GoodsDelivery
                {
                    Date = IsoTime.ParseISO8601String(split[0]),
                    Size = size ? EnumValidator.GetEnumValueByDescription<Size>(split[1]) : null,
                    Company = split.Length == 3 ? split[2] : split[1] + " Ignored"
                });
            }
            return list;
        }
    }
}
