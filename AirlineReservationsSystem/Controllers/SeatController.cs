using AirlineReservationsSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationsSystem.Controllers
{
    public class SeatController : Controller
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        
        public async Task<IActionResult> Index()
        {
            //var seats = await _seatService.GetAllSeatsAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookSeat(int seatId)
        {
            var userId = User.Identity.Name;
            //var success = await _seatService.BookSeatAsync(seatId, userId);

            //if (success)
            //{
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    ViewBag.ErrorMessage = "you can not bookin , try again";
                return View();
            //}
        }
    }
}
