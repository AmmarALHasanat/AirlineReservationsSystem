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
                new TravelRoute { TravelRouteId = 1, Origin = "AMM", Destination = "AQJ", EstimatedTime = "4h 0m" },
                new TravelRoute { TravelRouteId = 2, Origin = "AQJ", Destination = "AMM", EstimatedTime = "4h 0m" },

                new TravelRoute { TravelRouteId = 3, Origin = "AMM", Destination = "AUH", EstimatedTime = "3h 15m" },
                new TravelRoute { TravelRouteId = 4, Origin = "AUH", Destination = "AMM", EstimatedTime = "3h 15m" },

                new TravelRoute { TravelRouteId = 5, Origin = "AMM", Destination = "DXB", EstimatedTime = "3h 30m" },
                new TravelRoute { TravelRouteId = 6, Origin = "DXB", Destination = "AMM", EstimatedTime = "3h 30m" },

                new TravelRoute { TravelRouteId = 7, Origin = "AMM", Destination = "SHJ", EstimatedTime = "3h 40m" },
                new TravelRoute { TravelRouteId = 8, Origin = "SHJ", Destination = "AMM", EstimatedTime = "3h 40m" },

                new TravelRoute { TravelRouteId = 9, Origin = "AMM", Destination = "RKT", EstimatedTime = "1h 30m" },
                new TravelRoute { TravelRouteId = 10, Origin = "RKT", Destination = "AMM", EstimatedTime = "1h 30m" },

                new TravelRoute { TravelRouteId = 11, Origin = "AMM", Destination = "AAN", EstimatedTime = "2h 0m" },
                new TravelRoute { TravelRouteId = 12, Origin = "AAN", Destination = "AMM", EstimatedTime = "2h 0m" },

                new TravelRoute { TravelRouteId = 13, Origin = "AMM", Destination = "RUH", EstimatedTime = "3h 10m" },
                new TravelRoute { TravelRouteId = 14, Origin = "RUH", Destination = "AMM", EstimatedTime = "3h 10m" },

                new TravelRoute { TravelRouteId = 15, Origin = "AMM", Destination = "JED", EstimatedTime = "2h 50m" },
                new TravelRoute { TravelRouteId = 16, Origin = "JED", Destination = "AMM", EstimatedTime = "2h 50m" },

                new TravelRoute { TravelRouteId = 17, Origin = "AMM", Destination = "DMM", EstimatedTime = "3h 5m" },
                new TravelRoute { TravelRouteId = 18, Origin = "DMM", Destination = "AMM", EstimatedTime = "3h 5m" },

                new TravelRoute { TravelRouteId = 19, Origin = "AMM", Destination = "AHB", EstimatedTime = "3h 20m" },
                new TravelRoute { TravelRouteId = 20, Origin = "AHB", Destination = "AMM", EstimatedTime = "3h 20m" },

                new TravelRoute { TravelRouteId = 21, Origin = "AMM", Destination = "CAI", EstimatedTime = "1h 45m" },
                new TravelRoute { TravelRouteId = 22, Origin = "CAI", Destination = "AMM", EstimatedTime = "1h 45m" },

                new TravelRoute { TravelRouteId = 23, Origin = "AMM", Destination = "SSH", EstimatedTime = "3h 10m" },
                new TravelRoute { TravelRouteId = 24, Origin = "SSH", Destination = "AMM", EstimatedTime = "3h 10m" },

                new TravelRoute { TravelRouteId = 25, Origin = "AMM", Destination = "IST", EstimatedTime = "2h 45m" },
                new TravelRoute { TravelRouteId = 26, Origin = "IST", Destination = "AMM", EstimatedTime = "2h 45m" },

                new TravelRoute { TravelRouteId = 27, Origin = "AMM", Destination = "ESB", EstimatedTime = "4h 10m" },
                new TravelRoute { TravelRouteId = 28, Origin = "ESB", Destination = "AMM", EstimatedTime = "4h 10m" },

                new TravelRoute { TravelRouteId = 29, Origin = "AMM", Destination = "TZX", EstimatedTime = "2h 55m" },
                new TravelRoute { TravelRouteId = 30, Origin = "TZX", Destination = "AMM", EstimatedTime = "2h 55m" },

                new TravelRoute { TravelRouteId = 31, Origin = "AUH", Destination = "RUH", EstimatedTime = "2h 45m" },
                new TravelRoute { TravelRouteId = 32, Origin = "RUH", Destination = "AUH", EstimatedTime = "2h 45m" },

                new TravelRoute { TravelRouteId = 33, Origin = "AUH", Destination = "JED", EstimatedTime = "2h 20m" },
                new TravelRoute { TravelRouteId = 34, Origin = "JED", Destination = "AUH", EstimatedTime = "2h 20m" },

                new TravelRoute { TravelRouteId = 35, Origin = "AUH", Destination = "DMM", EstimatedTime = "2h 30m" },
                new TravelRoute { TravelRouteId = 36, Origin = "DMM", Destination = "AUH", EstimatedTime = "2h 30m" },

                new TravelRoute { TravelRouteId = 37, Origin = "AUH", Destination = "AHB", EstimatedTime = "2h 50m" },
                new TravelRoute { TravelRouteId = 38, Origin = "AHB", Destination = "AUH", EstimatedTime = "2h 50m" },

                new TravelRoute { TravelRouteId = 39, Origin = "AUH", Destination = "CAI", EstimatedTime = "3h 10m" },
                new TravelRoute { TravelRouteId = 40, Origin = "CAI", Destination = "AUH", EstimatedTime = "3h 10m" },

                new TravelRoute { TravelRouteId = 41, Origin = "AUH", Destination = "SSH", EstimatedTime = "3h 0m" },
                new TravelRoute { TravelRouteId = 42, Origin = "SSH", Destination = "AUH", EstimatedTime = "3h 0m" },

                new TravelRoute { TravelRouteId = 43, Origin = "AUH", Destination = "IST", EstimatedTime = "3h 30m" },
                new TravelRoute { TravelRouteId = 44, Origin = "IST", Destination = "AUH", EstimatedTime = "3h 30m" },

                new TravelRoute { TravelRouteId = 45, Origin = "AUH", Destination = "ESB", EstimatedTime = "4h 0m" },
                new TravelRoute { TravelRouteId = 46, Origin = "ESB", Destination = "AUH", EstimatedTime = "4h 0m" },

                new TravelRoute { TravelRouteId = 47, Origin = "AUH", Destination = "TZX", EstimatedTime = "3h 40m" },
                new TravelRoute { TravelRouteId = 48, Origin = "TZX", Destination = "AUH", EstimatedTime = "3h 40m" },

                new TravelRoute { TravelRouteId = 49, Origin = "DXB", Destination = "RUH", EstimatedTime = "2h 55m" },
                new TravelRoute { TravelRouteId = 50, Origin = "RUH", Destination = "DXB", EstimatedTime = "2h 55m" },

                new TravelRoute { TravelRouteId = 51, Origin = "DXB", Destination = "JED", EstimatedTime = "2h 25m" },
                new TravelRoute { TravelRouteId = 52, Origin = "JED", Destination = "DXB", EstimatedTime = "2h 25m" },

                new TravelRoute { TravelRouteId = 53, Origin = "DXB", Destination = "DMM", EstimatedTime = "2h 35m" },
                new TravelRoute { TravelRouteId = 54, Origin = "DMM", Destination = "DXB", EstimatedTime = "2h 35m" },

                new TravelRoute { TravelRouteId = 55, Origin = "DXB", Destination = "AHB", EstimatedTime = "3h 10m" },
                new TravelRoute { TravelRouteId = 56, Origin = "AHB", Destination = "DXB", EstimatedTime = "3h 10m" },

                new TravelRoute { TravelRouteId = 57, Origin = "DXB", Destination = "CAI", EstimatedTime = "3h 0m" },
                new TravelRoute { TravelRouteId = 58, Origin = "CAI", Destination = "DXB", EstimatedTime = "3h 0m" },

                new TravelRoute { TravelRouteId = 59, Origin = "DXB", Destination = "SSH", EstimatedTime = "3h 15m" },
                new TravelRoute { TravelRouteId = 60, Origin = "SSH", Destination = "DXB", EstimatedTime = "3h 15m" },

                new TravelRoute { TravelRouteId = 61, Origin = "DXB", Destination = "IST", EstimatedTime = "3h 10m" },
                new TravelRoute { TravelRouteId = 62, Origin = "IST", Destination = "DXB", EstimatedTime = "3h 10m" },

                new TravelRoute { TravelRouteId = 63, Origin = "DXB", Destination = "ESB", EstimatedTime = "4h 0m" },
                new TravelRoute { TravelRouteId = 64, Origin = "ESB", Destination = "DXB", EstimatedTime = "4h 0m" },

                new TravelRoute { TravelRouteId = 65, Origin = "DXB", Destination = "TZX", EstimatedTime = "3h 25m" },
                new TravelRoute { TravelRouteId = 66, Origin = "TZX", Destination = "DXB", EstimatedTime = "3h 25m" },

                new TravelRoute { TravelRouteId = 67, Origin = "RUH", Destination = "CAI", EstimatedTime = "3h 0m" },
                new TravelRoute { TravelRouteId = 68, Origin = "CAI", Destination = "RUH", EstimatedTime = "3h 0m" },

                new TravelRoute { TravelRouteId = 69, Origin = "RUH", Destination = "SSH", EstimatedTime = "3h 30m" },
                new TravelRoute { TravelRouteId = 70, Origin = "SSH", Destination = "RUH", EstimatedTime = "3h 30m" },

                new TravelRoute { TravelRouteId = 71, Origin = "RUH", Destination = "IST", EstimatedTime = "3h 0m" },
                new TravelRoute { TravelRouteId = 72, Origin = "IST", Destination = "RUH", EstimatedTime = "3h 0m" },

                new TravelRoute { TravelRouteId = 73, Origin = "RUH", Destination = "ESB", EstimatedTime = "3h 15m" },
                new TravelRoute { TravelRouteId = 74, Origin = "ESB", Destination = "RUH", EstimatedTime = "3h 15m" },

                new TravelRoute { TravelRouteId = 75, Origin = "RUH", Destination = "TZX", EstimatedTime = "3h 10m" },
                new TravelRoute { TravelRouteId = 76, Origin = "TZX", Destination = "RUH", EstimatedTime = "3h 10m" },

                new TravelRoute { TravelRouteId = 77, Origin = "IST", Destination = "ESB", EstimatedTime = "1h 40m" },
                new TravelRoute { TravelRouteId = 78, Origin = "ESB", Destination = "IST", EstimatedTime = "1h 40m" },

                new TravelRoute { TravelRouteId = 79, Origin = "IST", Destination = "TZX", EstimatedTime = "1h 30m" },
                new TravelRoute { TravelRouteId = 80, Origin = "TZX", Destination = "IST", EstimatedTime = "1h 30m" },

                new TravelRoute { TravelRouteId = 81, Origin = "ESB", Destination = "TZX", EstimatedTime = "1h 20m" },
                new TravelRoute { TravelRouteId = 82, Origin = "TZX", Destination = "ESB", EstimatedTime = "1h 20m" },
            };

            modelBuilder.Entity<TravelRoute>().HasData(travelRoutes);
        }
    }
}
