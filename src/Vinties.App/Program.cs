using Microsoft.Extensions.DependencyInjection;
using Vinties.Services.Services;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<ReadWriteTextFile>()
            .AddSingleton<ArrayToGoodsDelivery>()
            //.AddSingleton<MRDiscount>()
            .AddSingleton<DiscountCounter>()
            .AddSingleton<Discount>()
            .AddSingleton<GetDiscount>()
            .BuildServiceProvider();

        var discount = serviceProvider.GetService<Discount>();
        await discount.GetDiscountPrices();
    }
}


