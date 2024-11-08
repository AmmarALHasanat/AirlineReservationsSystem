using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservationsSystem.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;
        public BookingService(AppDbContext context) { _context = context; }

        public async Task CreateBookingAsync(Booking booking)
        {
            throw new NotImplementedException();
        }



        public async Task UpdateBookingAsync(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
