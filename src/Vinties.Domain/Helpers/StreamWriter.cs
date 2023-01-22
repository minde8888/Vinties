

namespace Vinties.Domain.Helpers
{
    public static class StreamWriter
    {
        public static void WriteLine(string[] lines)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\#C\Vinties\Vinties.txt"))
            {
                foreach (string line in lines)
                {
                    file.WriteLineAsync(line);
                }
            }
        }
    }
}
