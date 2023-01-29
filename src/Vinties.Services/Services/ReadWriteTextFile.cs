using Vinties.Domain.Models;

namespace Vinties.Services.Services
{
    public class ReadWriteTextFile
    {
        private readonly string input = @"D:\#C\Vinties\input.txt";
        private readonly string prices = @"D:\#C\Vinties\prices.txt";

        public async Task<List<GoodsDelivery>> ReadFileInput()
        {
            if (File.Exists(input))
            {
                string text = await File.ReadAllTextAsync(input);
                string[] lines = text.Split("\r\n");
                var prices = await ReadFilePices();

                return new ArrayToGoodsDelivery().DeliveryList(lines, prices);
            }
            throw new ArgumentNullException("text file not found");
        }

        private async Task<string[]> ReadFilePices()
        {
            if (File.Exists(prices))
            {
                string text = await File.ReadAllTextAsync(prices);
                string[] lines = text.Split("\r\n");

                return lines;
            }
            throw new ArgumentNullException("text file not found");
        }

        public void WriteFile(List<GoodsDelivery> list)
        {
            using (StreamWriter file = new StreamWriter(@"D:\#C\Vinties\Vinties1.txt"))
            {
                list.ForEach(x => file.WriteLine( $"{ x.Date.ToString("yyyy-MM-dd")} {x.Size} {x.Company} {x.Price} {x?.Discount}" ));
            }
        }

    }
}
