

using Vinties.Domain.Helpers;
using Vinties.Domain.Models;

namespace Vinties.Services.Services
{
    public class ReadTextFileService
    {
        private readonly string input = @"D:\#C\Vinties\input.txt";
        private readonly string prices = @"D:\#C\Vinties\prices.txt";

        public async Task<List<GoodsDelivery>> GetInput()
        {
            if (File.Exists(input))
            {
                string text = await File.ReadAllTextAsync(input);
                string[] lines = text.Split("\r\n");

                return new GoodsDeleveryList().DeliveryList(lines);
            }
            throw new ArgumentNullException("text file not found");
        }

        public async Task<string[]> GetPices()
        {
            if (File.Exists(prices))
            {
                string text = await File.ReadAllTextAsync(prices);
                string[] lines = text.Split("\r\n");

                return lines;
            }
            throw new ArgumentNullException("text file not found");
        }

    }
}
  