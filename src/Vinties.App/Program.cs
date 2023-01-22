using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Vinties.Domain.Models;
using Vinties.Services.Services;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<ReadTextFileService>()
            .AddSingleton<LPDiscount>()
            .AddSingleton<MRDiscount>()
            .AddSingleton<IgnoredDiscountControll>()
            .AddSingleton<BaseDiscount>()
            .AddSingleton<Discount>()
            .AddSingleton<GetDiscount>()
            .BuildServiceProvider();

        serviceProvider.GetServices<ILoggerFactory>();

        var logger = serviceProvider.GetService<ILoggerFactory>()
            .CreateLogger<Program>();

        logger.LogDebug("Starting application");

        var discount = serviceProvider.GetService<Discount>();
        await discount.LPDPrices();

        logger.LogDebug("All done!");
    }
}


