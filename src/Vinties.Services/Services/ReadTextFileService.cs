

namespace Vinties.Services.Services
{
    public class ReadTextFileService
    {
        private readonly string path = @"D:\#C\Vinties\input.txt";
        public async Task<string[]> GetText()
        {
            if (File.Exists(path))
            {
                string text = await File.ReadAllTextAsync(path);
                string[] lines = text.Split("\r\n");

                return lines;
            }
            throw new ArgumentNullException("text file not found");
        }
    }
}
