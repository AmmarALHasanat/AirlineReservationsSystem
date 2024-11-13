using AirlineReservationsSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationsSystem.Controllers.Dashboard
{
    [Authorize(policy: "AdminOnly")]
    [Area("Dashboard")]
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        // GET: Dashboard/Airplane/Index
        public async Task<IActionResult> Index()
        {
            var airplanes = await _flightService.GetAllFlightsAsync();
            return View(airplanes);
        }
    }
}
