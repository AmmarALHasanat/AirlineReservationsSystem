using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Infrastructure.Data;

namespace AirlineReservationsSystem.Application.Services
{
    public class SeatService: ISeatService
    {
        private readonly AppDbContext _context;
        public SeatService(AppDbContext context) { _context = context; }
    }
}
