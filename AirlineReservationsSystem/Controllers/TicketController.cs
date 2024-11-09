using AirlineReservationsSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationsSystem.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // عرض جميع التذاكر الخاصة بالمستخدم
        public async Task<IActionResult> Index()
        {
            var userId = User.Identity.Name; // الحصول على الـ UserId من الجلسة أو Authentication
            var tickets = await _ticketService.GetUserTicketsAsync(userId);
            return View(tickets);
        }

        // إصدار تذكرة جديدة بناءً على الحجز
        public async Task<IActionResult> IssueTicket(int bookingId)
        {
            var userId = User.Identity.Name;
            var ticket = await _ticketService.IssueTicketAsync(bookingId, userId);
            if (ticket != null)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        // إلغاء التذكرة
        public async Task<IActionResult> CancelTicket(int ticketId)
        {
            var result = await _ticketService.CancelTicketAsync(ticketId);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        // تحديث حالة التذكرة
        public async Task<IActionResult> UpdateStatus(int ticketId, string status)
        {
            var result = await _ticketService.UpdateTicketStatusAsync(ticketId, status);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
