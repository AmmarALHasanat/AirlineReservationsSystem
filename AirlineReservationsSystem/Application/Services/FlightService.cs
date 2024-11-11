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

        public async Task CreateFlightAsync(Flight flight)
        {
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFlightAsync(Flight flight)
        {
            _context.Flights.Update(flight);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlightAsync(int flightId)
        {
            var flight = await _context.Flights.FindAsync(flightId);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                await _context.SaveChangesAsync();
            }
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
