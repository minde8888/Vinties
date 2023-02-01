using System.Reflection;
using Vinties.Domain.Models;

namespace Vinties.Services.Services
{
    public class FileService
    {
        private readonly string input = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\Data\input.txt");
        private readonly string prices = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\Data\prices.txt");
        private readonly string output = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\Data\output.txt");

        public async Task<List<GoodsDelivery>> ReadInput()
        {
         
            if (File.Exists(input))
            {
                string text = await File.ReadAllTextAsync(input);
                string[] lines = text.Split("\r\n");
                var prices = await ReadFilePices();

                return new DateConvertServices().ConvertToDeliverys(lines, prices);
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
            using (StreamWriter file = new StreamWriter(output))
            {
                list.ForEach(x => file.WriteLine($"{x.Date.ToString("yyyy-MM-dd")} {x.Size} {x.Company} {x.Price} {x?.Discount}"));
            }

        }
    }
}
