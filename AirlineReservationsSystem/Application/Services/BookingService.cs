﻿using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Infrastructure.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservationsSystem.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;

        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetAllBookingsByUserIdAsync(string userId)
        {

            return await _context.Bookings
                                 .Where(b => b.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<Booking?> GetBookingByIdAsync(string userId, int bookingId)
        {
            return await _context.Bookings.Include(b=> b.Tickets)
                                 .FirstOrDefaultAsync(b => b.UserId == userId && b.BookingId == bookingId);
        }


        public async Task CreateBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            //if (booking != null)
            //{
            //    _context.Bookings.Remove(booking);
            //    await _context.SaveChangesAsync();
            //}
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }



    }

}
