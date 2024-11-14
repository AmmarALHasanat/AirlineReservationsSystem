using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservationsSystem.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly AppDbContext _context;

        public FlightService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Flight>> GetAvailableFlightsAsync(string from, string to, DateTime? departureDate, DateTime? returnDate, string tripType)
        {
            var query = _context.Flights.AsQueryable();

            if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
            {
                var routeId = _context.Routes.FirstOrDefault(r => r.Origin == from && r.Destination == to)?.TravelRouteId;
                if(tripType == "roundTrip")
                {
                    var routeId2 = _context.Routes.FirstOrDefault(r => r.Origin == to && r.Destination == from)?.TravelRouteId;
                }

                if (routeId.HasValue)
                {
                    query = query.Where(f => f.TravelRouteId == routeId.Value);
                }
                else
                {
                    return new List<Flight>();
                }
            }


            if (departureDate.HasValue)
            {
                query = query.Where(f => f.DepartureTime.Date == departureDate.Value.Date);
            }

            if (tripType == "roundTrip" && returnDate.HasValue)
            {
                query = query.Where(f => f.ArrivalTime.Date == returnDate.Value.Date);
            }

            return await query.ToListAsync();
        }



        public async Task CreateFlightAsync(Flight flight)
        {
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();
        }


        // create or update fligth by admin roule only 
        // search for AirportNames and add key + city >> file in Domain/Dictionaries/AirportNames.cs
        // or company name



        public async Task<Flight> GetFlightByIdAsync(int flightId)
        {
            return await _context.Flights.FindAsync(flightId);
        }

        public async Task<List<Flight>> GetAllFlightsAsync()
        {
            return await _context.Flights.ToListAsync();
        }
    }
}
