using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Domain.Enums;
using AirlineReservationsSystem.Infrastructure.Data;
using AirlineReservationsSystem.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AirlineReservationsSystem.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly AppDbContext _context;

        public FlightService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Flight>> GetAvailableFlightsAsync(string from, string to, DateTime departureDate, DateTime? returnDate, TripType? tripType)
        {
            var query = _context.Flights.AsQueryable();

            if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
            {
                var routeId = _context.Routes.FirstOrDefault(r => r.Origin == from && r.Destination == to)?.TravelRouteId;

                if (routeId.HasValue)
                {
                    query = query.Where(f => f.TravelRouteId == routeId.Value);
                }
                else
                {
                    return new List<Flight>();
                }
            }
            query = query.Where(f => EF.Functions.DateDiffDay(f.DepartureTime, departureDate) == 0);


            return await query.ToListAsync();
        }



        public async Task CreateFlightAsync(Flight flight, Dictionary<SeatType, decimal> prices)
        {
            try
            {
                _context.Flights.Add(flight);

                var seats = await _context.Seats
                                          .Where(s => s.AirplaneId == flight.AirplaneId)
                                          .ToListAsync();

                if (seats == null || !seats.Any())
                {
                    throw new InvalidOperationException("No seats found for the specified airplane.");
                }

                var flightSeats = seats.Select(seat => new FlightSeat
                {
                    SeatId = seat.SeatId,
                    FlightId = flight.FlightId,
                    SeatPrice = prices.ContainsKey(seat.Class) ? prices[seat.Class] : 
                            throw new KeyNotFoundException($"Price for seat type {seat.Class} not found."),
                    AvailableSeats = seat.TotalNumber 
                }).ToList();

                flight.FlightSeats.AddRange(flightSeats);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating flight: {ex.Message}");
                throw;
            }
        }



        // search for AirportNames and add key + city >> file in Domain/Dictionaries/AirportNames.cs
        // or company name

        public async Task<Flight?> GetFlightByIdAsync(int flightId)
        {

            return await _context.Flights
                .Include(f => f.Airplane)
                .Include(f => f.Route)
                .Include(f => f.FlightSeats)
                .ThenInclude(fs => fs.Seat)
                .FirstOrDefaultAsync(f => f.FlightId == flightId);
        }

        public async Task<List<Flight>> GetAllFlightsAsync()
        {
            return await _context.Flights
                .Include(f => f.Airplane)
                .Include(f => f.Route)
                .Where(f => f.DepartureTime >= DateTime.Now).ToListAsync();
        }
    }
}
