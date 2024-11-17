using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Domain.Enums;
using AirlineReservationsSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservationsSystem.Controllers.Dashboard
{
    [Authorize(policy: "AdminOnly")]
    [Area("Dashboard")]
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IAirplaneService _airplaneService;
        private readonly ITravelRouteService _travelRouteService;


        public FlightController(IFlightService flightService, IAirplaneService airplaneService, ITravelRouteService travelRouteService)
        {
            _flightService = flightService;
            _airplaneService = airplaneService;
            _travelRouteService = travelRouteService;
        }

        // GET: Dashboard/Airplane/Index
        public async Task<IActionResult> Index()
        {
            var flights = await _flightService.GetAllFlightsAsync();
            return View(flights);
        }
        public async Task<IActionResult> Create()
        {
            var airplanes = await _airplaneService.GetAllAirplanesAsync();
            var routes = await _travelRouteService.GetAllRoutesAsync();

            // Prepare a view model to pass to the view (you might need to create a ViewModel)
            var viewModel = new CreateFlightViewModel
            {
                Airplanes = airplanes,
                Routes = routes,
                DepartureTime = DateTime.Now.AddDays(1),
                ArrivalTime = DateTime.Now.AddDays(1),
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFlightViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Flight flight = new Flight
                    {
                        FlightNumber = viewModel.FlightNumber,
                        DepartureTime = viewModel.DepartureTime,
                        ArrivalTime = viewModel.ArrivalTime,
                        AirplaneId = viewModel.AirplaneId,
                        TravelRouteId = viewModel.TravelRouteId,
                    };
                    Dictionary<SeatType, decimal> prices = new Dictionary<SeatType, decimal> {
                        { SeatType.Business, viewModel.BusinessClassPrice},
                        { SeatType.Economy, viewModel.EconomyClassPrice},
                        { SeatType.FirstClass, viewModel.FirstClassPrice},
                    };

                    await _flightService.CreateFlightAsync(flight, prices);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View("Error", new { message = ex.Message });
                }
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors)
                                           .Select(e => e.ErrorMessage)
                                           .ToList();
            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }

            return View(viewModel);

        }


        // Details

        public async Task<IActionResult> Details(int id)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);
            if (flight== null)
            {
                return NotFound();
            }
            return View(flight);
        }

    }
}
