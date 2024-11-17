using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AirlineReservationsSystem.Controllers
{
    [Authorize(policy: "UserOnly")]
    
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // لعرض كل الحجوزات
        public async Task<IActionResult> Index()  // must add getbookinguserId 
        {
            
            var bookings = await _bookingService.GetAllBookingsAsync();
            return View(bookings);
        }

        // يمكنك إضافة دوال أخرى مثل Create و Edit و Delete حسب الحاجة
    }
}
