using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Infrastructure.Data;

namespace AirlineReservationsSystem.Application.Services
{
    public class AirplaneeService : IAirplaneeService
    {
        private readonly AppDbContext _context;
        public AirplaneeService(AppDbContext context) { _context = context; }
    }
}
