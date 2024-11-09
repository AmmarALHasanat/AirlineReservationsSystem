using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Domain.Enums; // تأكد من تضمين الـ Enum
using AirlineReservationsSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservationsSystem.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly AppDbContext _context;

        public TicketService(AppDbContext context)
        {
            _context = context;
        }

        // إصدار تذكرة جديدة بناءً على الحجز
        public async Task<Ticket> IssueTicketAsync(int bookingId, string userId)
        {
            var booking = await _context.Bookings
                .Include(b => b.FlightSeats)
                .FirstOrDefaultAsync(b => b.BookingId == bookingId && b.UserId == userId);

            if (booking == null)
            {
                return null; // لا يوجد حجز مطابق
            }

            var ticket = new Ticket
            {
                BookingId = bookingId,
                UserId = userId,
                FlightId = booking.FlightSeats.FirstOrDefault()?.FlightId ?? 0,
                Status = TicketStatus.Issued,  // تعيين الحالة كـ "Issued" باستخدام الـ Enum
                IssueDate = DateTime.Now // تعيين تاريخ الإصدار
            };

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return ticket; // إرجاع التذكرة التي تم إصدارها
        }

        // جلب جميع التذاكر الخاصة بالمستخدم
        public async Task<IEnumerable<Ticket>> GetUserTicketsAsync(string userId)
        {
            return await _context.Tickets
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        // جلب تذكرة معينة حسب الـ ID
        public async Task<Ticket> GetTicketByIdAsync(int ticketId)
        {
            return await _context.Tickets.FirstOrDefaultAsync(t => t.TicketId == ticketId);
        }

        // إلغاء التذكرة
        public async Task<bool> CancelTicketAsync(int ticketId)
        {
            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(t => t.TicketId == ticketId);

            if (ticket == null)
            {
                return false; // التذكرة غير موجودة
            }

            ticket.Status = TicketStatus.Cancelled; // تغيير حالة التذكرة إلى "Cancelled" باستخدام الـ Enum
            await _context.SaveChangesAsync();

            return true;
        }

        // تحديث حالة التذكرة
        public async Task<bool> UpdateTicketStatusAsync(int ticketId, string status)
        {
            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(t => t.TicketId == ticketId);

            if (ticket == null)
            {
                return false; // التذكرة غير موجودة
            }

            // تحويل الـ status من string إلى TicketStatus باستخدام Enum.Parse
            if (Enum.TryParse(status, out TicketStatus ticketStatus))
            {
                ticket.Status = ticketStatus; // تحديث الحالة باستخدام الـ Enum
                await _context.SaveChangesAsync();

                return true;
            }

            return false; // إذا كانت القيمة غير صحيحة
        }
    }
}
