using AirlineReservationsSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationsSystem.Controllers.Dashboard
{
    [Area("Dashboard")]
    public class TravelRouteController : Controller
    {
        private readonly ITravelRouteService _travelRouteService;

        public TravelRouteController(ITravelRouteService travelRouteService)
        {
            _travelRouteService = travelRouteService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 15)
        {
            var routes =  _travelRouteService.GetPaginatedRoutesAsync(pageNumber, pageSize);
            ViewBag.FirstPageNumber = 1;
            ViewBag.LastPageNumber = routes.PageCount; 

            return View(routes);
        }
    }
}
