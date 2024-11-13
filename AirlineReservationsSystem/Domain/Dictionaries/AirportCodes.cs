using System.Collections.Generic;

namespace AirlineReservationsSystem.Domain.Dictionaries
{
    public static class AirportCodes
    {
        public static readonly Dictionary<string, (string City, string Airport)> Codes = new Dictionary<string, (string City, string Country)>
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
            { "MED", ("Madinah", "Saudi Arabia") },
            { "AHB", ("Abha", "Saudi Arabia") },
            { "TIF", ("Taif", "Saudi Arabia") },

            // (Egypt)
            { "CAI", ("Cairo", "Egypt") },
            { "HBE", ("Alexandria", "Egypt") },
            { "SSH", ("Sharm El Sheikh", "Egypt") },
            { "LXR", ("Luxor", "Egypt") },
            { "HRG", ("Hurghada", "Egypt") },
            { "ASW", ("Aswan", "Egypt") },

            // (Turkey)
            { "IST", ("Istanbul", "Turkey") },
            { "ESB", ("Ankara", "Turkey") },
            { "ADB", ("Izmir", "Turkey") },
            { "AYT", ("Antalya", "Turkey") },
            { "BJV", ("Bodrum", "Turkey") },
            { "TZX", ("Trabzon", "Turkey") },

            // (Kuwait)
            { "KWI", ("Kuwait City", "Kuwait") },

        };
    }
}
