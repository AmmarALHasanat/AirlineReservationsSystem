using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AirlineReservationsSystem.Domain.Entities;

namespace AirlineReservationsSystem.Infrastructure.Data
{
    public static class TravelRouteSeeder
    {
        public static void Run(ModelBuilder modelBuilder)
        {
            var travelRoutes = new List<TravelRoute>
            {
                // الأردن (Jordan)
                new TravelRoute {TravelRouteId=1, Origin = "AMM", Destination = "AQJ", EstimatedTime = "4h 0m" },
                new TravelRoute {TravelRouteId=2, Origin = "AMM", Destination = "DXB", EstimatedTime = "3h 45m" },
                new TravelRoute {TravelRouteId=3, Origin = "AMM", Destination = "RUH", EstimatedTime = "2h 0m" },
                new TravelRoute {TravelRouteId=4, Origin = "AQJ", Destination = "DXB", EstimatedTime = "2h 30m" },

                // الإمارات العربية المتحدة (UAE)
                new TravelRoute {TravelRouteId = 5,  Origin = "AUH", Destination = "DXB", EstimatedTime = "1h 10m" },
                new TravelRoute {TravelRouteId = 6,  Origin = "AUH", Destination = "SHJ", EstimatedTime = "1h 0m" },
                new TravelRoute {TravelRouteId = 7,  Origin = "DXB", Destination = "SHJ", EstimatedTime = "1h 0m" },
                new TravelRoute {TravelRouteId = 8,  Origin = "DXB", Destination = "RUH", EstimatedTime = "1h 50m" },
                new TravelRoute {TravelRouteId = 9,  Origin = "AAN", Destination = "AUH", EstimatedTime = "1h 30m" },

                // المملكة العربية السعودية (Saudi Arabia)
                new TravelRoute {TravelRouteId = 10,  Origin = "RUH", Destination = "JED", EstimatedTime = "1h 15m" },
                new TravelRoute {TravelRouteId = 11,  Origin = "RUH", Destination = "DMM", EstimatedTime = "1h 40m" },
                new TravelRoute {TravelRouteId = 12,  Origin = "RUH", Destination = "MED", EstimatedTime = "1h 30m" },
                new TravelRoute {TravelRouteId = 13,  Origin = "RUH", Destination = "AHB", EstimatedTime = "1h 40m" },
                new TravelRoute {TravelRouteId = 14,  Origin = "RUH", Destination = "TIF", EstimatedTime = "1h 25m" },

                // مصر (Egypt)
                new TravelRoute {TravelRouteId = 15,  Origin = "CAI", Destination = "HBE", EstimatedTime = "1h 0m" },
                new TravelRoute {TravelRouteId = 16,  Origin = "CAI", Destination = "SSH", EstimatedTime = "1h 30m" },
                new TravelRoute {TravelRouteId = 17,  Origin = "CAI", Destination = "LXR", EstimatedTime = "1h 0m" },
                new TravelRoute {TravelRouteId = 18,  Origin = "CAI", Destination = "HRG", EstimatedTime = "1h 10m" },
                new TravelRoute {TravelRouteId = 19,  Origin = "CAI", Destination = "ASW", EstimatedTime = "1h 20m" },

                // تركيا (Turkey)
                new TravelRoute {TravelRouteId = 20,  Origin = "IST", Destination = "ESB", EstimatedTime = "1h 15m" },
                new TravelRoute {TravelRouteId = 21,  Origin = "IST", Destination = "ADB", EstimatedTime = "1h 10m" },
                new TravelRoute {TravelRouteId = 22,  Origin = "IST", Destination = "AYT", EstimatedTime = "1h 25m" },
                new TravelRoute {TravelRouteId = 23,  Origin = "IST", Destination = "BJV", EstimatedTime = "1h 15m" },
                new TravelRoute {TravelRouteId = 24,  Origin = "IST", Destination = "TZX", EstimatedTime = "1h 30m" },

                // الكويت (Kuwait)
                new TravelRoute {TravelRouteId = 25,  Origin = "KWI", Destination = "DXB", EstimatedTime = "1h 30m" },
                new TravelRoute {TravelRouteId = 26,  Origin = "KWI", Destination = "RUH", EstimatedTime = "1h 30m" },
            };

            // Adding the travel routes to the model data
            modelBuilder.Entity<TravelRoute>().HasData(travelRoutes);
        }
    }
}
