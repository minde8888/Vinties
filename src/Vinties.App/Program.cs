using Microsoft.Extensions.DependencyInjection;
using Vinties.Services.Discount;
using Vinties.Services.Services;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<ReadWriteTextFile>()
            .AddSingleton<ArrayToGoodsDelivery>()
            .AddSingleton<DiscountCounter>()
            .AddSingleton<LPDiscountCounter>()
            .AddSingleton<MRDiscountCounter>()
            .AddSingleton<ExecuteDiscount>()
            .BuildServiceProvider();

        var discount = serviceProvider.GetService<ExecuteDiscount>();
        await discount.GetDiscountPrices();
    }
}


