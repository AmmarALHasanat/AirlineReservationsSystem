using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationsSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public IActionResult Index()
        {
             //var Bo = _bookingService.GetAllBookingsByUserIdAsync(5);
            return View();
        }
    }
}
