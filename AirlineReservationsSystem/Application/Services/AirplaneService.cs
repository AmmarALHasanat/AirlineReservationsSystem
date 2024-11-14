using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservationsSystem.Application.Services
{
    public class AirplaneService : IAirplaneService
    {
        private readonly AppDbContext _context;
        public AirplaneService(AppDbContext context) { _context = context; }


        public async Task<List<Airplane>> GetAllAirplanesAsync()
        {
            // reatun seats realtionn with Airplanes
            return await _context.Airplanes.Include(a => a.Seats).ToListAsync();
        }

        public async Task<Airplane?> GetAirplaneByIdAsync(int id)
        {
            return await _context.Airplanes
                .Include(a => a.Seats)
                .FirstOrDefaultAsync(a => a.AirplaneId == id);
        }

        public async Task AddAirplaneAsync(Airplane airplane)
        {
            _context.Airplanes.Add(airplane);

            await _context.SaveChangesAsync();

        }

        public async Task<Airplane?> UpdateAirplaneAsync(Airplane airplane)
        {
            
            var existingAirplane = await _context.Airplanes
                .Include(a => a.Seats)
                .FirstOrDefaultAsync(a => a.AirplaneId == airplane.AirplaneId);

            if (existingAirplane == null)
                return null;

            // Update airplane properties
            existingAirplane.Model = airplane.Model;
            existingAirplane.Capacity = airplane.Capacity;

            // Update seats
            foreach (var updatedSeat in airplane.Seats)
            {
                var existingSeat = existingAirplane.Seats
                    .FirstOrDefault(s => s.SeatId == updatedSeat.SeatId);

                if (existingSeat != null)
                {
                    //existingSeat.Class = updatedSeat.Class;
                    existingSeat.TotalNumber = updatedSeat.TotalNumber;
                }
            }

            await _context.SaveChangesAsync();

            return existingAirplane;
        }


    }
}
