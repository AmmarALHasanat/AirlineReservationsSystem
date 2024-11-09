using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Infrastructure.Data;

namespace AirlineReservationsSystem.Application.Services
{
    public class TravelRouteService: ITravelRouteService
    {
        private readonly AppDbContext _context;
        public TravelRouteService(AppDbContext context) { _context = context; }
    }
}
