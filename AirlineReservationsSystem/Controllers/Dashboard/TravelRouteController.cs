using AirlineReservationsSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationsSystem.Controllers.Dashboard
{
    public class TravelRouteController : Controller
    {
        private readonly ITravelRouteService _travelRouteService;

        public TravelRouteController(ITravelRouteService travelRouteService)
        {
            _travelRouteService = travelRouteService;
        }

        public async Task<IActionResult> Index()
        {
            var routes = await _travelRouteService.GetAllRoutesAsync();
            return View(routes);
        }
    }
}
