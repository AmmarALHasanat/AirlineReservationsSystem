using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AirlineReservationsSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFlightService _flightService;
        public HomeController(ILogger<HomeController> logger, IFlightService flightService)
        {
            _logger = logger;
            _flightService = flightService;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Index()
        {
            FlightSearchViewModel flightSearchView = new FlightSearchViewModel { DepartureDate = DateTime.Now.AddDays(1), TripType= TripType.OneWay, };
            return View(flightSearchView);
        }

        [HttpPost]
        public async Task<IActionResult> SearchFlights([FromBody] FlightSearchViewModel flightSearchView)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Any())
                    .ToDictionary(
                        kvp => kvp.Key.Split('.').Last(),
                        kvp => kvp.Value.Errors.First().ErrorMessage
                    );

                return UnprocessableEntity(errors);
            }

            // Fetch available flights
            var availableFlights = await _flightService.GetAvailableFlightsAsync(
                flightSearchView.From,
                flightSearchView.To,
                flightSearchView.DepartureDate,
                flightSearchView.ReturnDate,
                flightSearchView.TripType
            );

            return PartialView("_AvailableFlightsPartial", availableFlights);
        }

    }
}

//[HttpPost]
//public IActionResult SearchFlights(string from, string to, DateTime? departureDate, DateTime? returnDate, string tripType)
//{
//    if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to) || string.IsNullOrWhiteSpace(tripType))
//    {
//        ModelState.AddModelError(string.Empty, "All fields must be filled out.");
//    }

//    if (!ModelState.IsValid)
//    {
//        ViewData["codes"] = AirportCodes.Codes;
//        return View("Index");
//    }

//    var availableFlights = GetAvailableFlights(from, to, departureDate, returnDate, tripType);

//    if (availableFlights == null || !availableFlights.Any())
//    {
//        ViewBag.Message = "No flights available for your search criteria.";
//    }

//    var viewModel = new FlightSearchViewModel
//    {
//        From = from,
//        To = to,
//        ReturnDate = returnDate,
//        AvailableFlights = availableFlights
//    };

//    return View("Index", viewModel);
//}