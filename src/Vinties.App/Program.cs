using Microsoft.Extensions.DependencyInjection;
using Vinties.Domain.Interfaces;
using Vinties.Services.Discount;
using Vinties.Services.Services;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<ILPDiscountCounter, LPDiscountCounter>()
            .AddSingleton<IMRDiscount, MRDiscount>()
            .AddSingleton<FileService>()
            .AddSingleton<DiscountService>()
            .AddSingleton<DateConvertServices>()
            .AddSingleton<Runner>()
            .BuildServiceProvider();

        var discount = serviceProvider.GetService<Runner>();
        await discount.GetDiscountPrices();
    }
}


