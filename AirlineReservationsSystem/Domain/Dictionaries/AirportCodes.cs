using Humanizer;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace AirlineReservationsSystem.Domain.Dictionaries
{
    public static class AirportCodes
    {
        public static readonly Dictionary<string, (string City, string Country)> Codes = new Dictionary<string, (string City, string Country)>
        {
            // (Jordan)
            { "AMM", ("Amman", "Jordan") },
            { "AQJ", ("Aqaba", "Jordan") },

            // الإمارات العربية المتحدة (UAE)
            { "AUH", ("Abu Dhabi", "UAE") },
            { "DXB", ("Dubai", "UAE") },
            { "SHJ", ("Sharjah", "UAE") },
            { "RKT", ("Ras Al Khaimah", "UAE") },
            { "AAN", ("Al Ain", "UAE") },

            // (Saudi Arabia)
            { "RUH", ("Riyadh", "Saudi Arabia") },
            { "JED", ("Jeddah", "Saudi Arabia") },
            { "DMM", ("Dammam", "Saudi Arabia") },
            { "AHB", ("Abha", "Saudi Arabia") },

            // (Egypt)
            { "CAI", ("Cairo", "Egypt") },
            { "SSH", ("Sharm El Sheikh", "Egypt") },

            // (Turkey)
            { "IST", ("Istanbul", "Turkey") },
            { "ESB", ("Ankara", "Turkey") },
            { "TZX", ("Trabzon", "Turkey") },

        };
    }
}
// Dictionary get key 