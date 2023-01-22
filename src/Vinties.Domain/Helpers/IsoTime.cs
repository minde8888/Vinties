using System.Globalization;

namespace Vinties.Domain.Helpers
{
    public static class IsoTime
    {
        static readonly string[] formats = {

            "yyyyMMddTHHmmsszzz",
            "yyyyMMddTHHmmsszz",
            "yyyyMMddTHHmmssZ",

            "yyyy-MM-ddTHH:mm:sszzz",
            "yyyy-MM-ddTHH:mm:sszz",
            "yyyy-MM-ddTHH:mm:ssZ",

            "yyyyMMddTHHmmzzz",
            "yyyyMMddTHHmmzz",
            "yyyyMMddTHHmmZ",
            "yyyy-MM-ddTHH:mmzzz",
            "yyyy-MM-ddTHH:mmzz",
            "yyyy-MM-ddTHH:mmZ",

            "yyyyMMddTHHzzz",
            "yyyyMMddTHHzz",
            "yyyyMMddTHHZ",
            "yyyy-MM-ddTHHzzz",
            "yyyy-MM-ddTHHzz",
            "yyyy-MM-ddTHHZ",
            "yyyy-MM-dd"
        };
        public static DateTime ParseISO8601String(string str)
        {
            var date = DateTime.ParseExact(str, formats,
                CultureInfo.InvariantCulture, DateTimeStyles.None);
            return date;
        }
    }
}
