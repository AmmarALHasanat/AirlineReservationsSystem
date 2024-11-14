using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationsSystem.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new FlightSearchViewModel
            {
                AvailableFlights = new List<Flight>() // Initialize with an empty list
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> SearchFlights(string from, string to, DateTime? departureDate, DateTime? returnDate, string tripType)
        {
            var availableFlights = await _flightService.GetAvailableFlightsAsync(from, to, departureDate, returnDate, tripType);

            var viewModel = new FlightSearchViewModel
            {
                From = from,
                To = to,
                DepartureDate = departureDate,
                ReturnDate = returnDate,
                TripType = tripType,
                AvailableFlights = availableFlights
            };

            return PartialView("_AvailableFlights", viewModel.AvailableFlights);
        }

    }
}
