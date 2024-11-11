using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservationsSystem.Application.Services
{
    public class AirplaneService : IAirplaneService
    {
        private readonly AppDbContext _context;
        public AirplaneService(AppDbContext context) { _context = context; }
        public async Task<List<Airplane>> GetAllAirplanesAsync()
        {
            return await _context.Airplanes.ToListAsync();
        }
    }
}
