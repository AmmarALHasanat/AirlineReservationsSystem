using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineReservationsSystem.Application.Services
{
    public class SeatService : ISeatService
    {
        private readonly AppDbContext _context;

        public SeatService(AppDbContext context)
        {
            _context = context;
        }

        // جلب كل المقاعد
        public async Task<IEnumerable<Seat>> GetAllSeatsAsync()
        {
            return await _context.Seats.ToListAsync();
        }

        // جلب مقعد معين حسب الـ ID
        public async Task<Seat> GetSeatByIdAsync(int seatId)
        {
            return await _context.Seats.FirstOrDefaultAsync(s => s.SeatId == seatId);
        }

        // جلب المقاعد المتاحة لرحلة معينة
        public async Task<IEnumerable<Seat>> GetAvailableSeatsAsync(int flightId)
        {
            // من المفترض أن FlightSeat يمثل الحجز للرحلة والمقعد
            var bookedSeats = await _context.FlightSeats
                .Where(fs => fs.FlightId == flightId)
                .Select(fs => fs.SeatId)
                .ToListAsync();

            return await _context.Seats
                .Where(s => !bookedSeats.Contains(s.SeatId))
                .ToListAsync();
        }

        // حجز مقعد
        public async Task<bool> BookSeatAsync(int seatId, string userId)
        {
            // تحقق إذا كان المقعد موجودًا
            var seat = await _context.Seats.FirstOrDefaultAsync(s => s.SeatId == seatId);

            if (seat == null)
            {
                return false;
            }

            // تحقق من عدم حجز المقعد مسبقًا
            var existingBooking = await _context.FlightSeats
                .AnyAsync(fs => fs.SeatId == seatId);

            if (existingBooking)
            {
                return false;
            }

            // حجز المقعد
            var flightSeat = new FlightSeat
            {
                SeatId = seatId,
                UserId = userId,
                FlightId = 1, // تحتاج إلى تحديد الـ FlightId المناسب
            };

            _context.FlightSeats.Add(flightSeat);
            await _context.SaveChangesAsync();

            return true;
        }

        // تحرير مقعد
        public async Task<bool> ReleaseSeatAsync(int seatId)
        {
            // تحقق من حجز المقعد
            var flightSeat = await _context.FlightSeats
                .FirstOrDefaultAsync(fs => fs.SeatId == seatId);

            if (flightSeat == null)
            {
                return false;
            }

            // إزالة الحجز
            _context.FlightSeats.Remove(flightSeat);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
