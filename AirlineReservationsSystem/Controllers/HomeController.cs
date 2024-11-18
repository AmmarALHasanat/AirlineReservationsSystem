using AirlineReservationsSystem.Domain.Dictionaries;
using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AirlineReservationsSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult SearchFlights(string from, string to, DateTime? departureDate, DateTime? returnDate, string tripType)
        {
            if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to) || string.IsNullOrWhiteSpace(tripType))
            {
                ModelState.AddModelError(string.Empty, "All fields must be filled out.");
            }

            if (!ModelState.IsValid)
            {
                ViewData["codes"] = AirportCodes.Codes;
                return View("Index");
            }

            var availableFlights = GetAvailableFlights(from, to, departureDate, returnDate, tripType);

            if (availableFlights == null || !availableFlights.Any())
            {
                ViewBag.Message = "No flights available for your search criteria.";
            }

            var viewModel = new FlightSearchViewModel
            {
                From = from,
                To = to,
                DepartureDate = departureDate,
                ReturnDate = returnDate,
                TripType = tripType,
                AvailableFlights = availableFlights
            };

            return View("Index", viewModel);
        }

        private List<Flight> GetAvailableFlights(string from, string to, DateTime? departureDate, DateTime? returnDate, string tripType)
        {
            return new List<Flight>();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Index()
        {
            // new Cach in momary ....

            ViewData["codes"] = AirportCodes.Codes;
            return View();
        }

    }
}

