
using Vinties.Domain.Helpers;

namespace Tests.Helpers
{
    public class IsoTimeTest
    {
        [Fact]
        public void ParseISO8601String_GivenString_ReturnDateTime()
        {
            var result = IsoTime.ParseISO8601String("2022-01-01");
            var date = new DateTime(2022, 01, 01);
            Assert.Equal(result, date);
        }
    }
}
