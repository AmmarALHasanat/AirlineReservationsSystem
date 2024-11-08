using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Infrastructure.Data;

namespace AirlineReservationsSystem.Application.Services
{
    public class FlightService: IFlightService
    {
        private readonly AppDbContext _context;
        public FlightService(AppDbContext context) { _context = context; }
    }
}
