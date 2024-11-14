using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                DepartureTime = DateTime.Now,
                ArrivalTime = DateTime.Now
            };

            return View(viewModel);
        }

        //public async Task<IActionResult> Create()
        //{
        //    // flight.AirplaneId
        //    //flight.TravelRouteId
        //    //flight.ArrivalTime
        //    //flight.DepartureTime
        //    //flight.Route.EstimatedTime
        //    //flight.FlightNumber
        //    //flight.FlightSeats >> flight.Airplane.Seats[0].SeatId flight.Airplane.Seats[0].FlightSeats
        //    // FlightSeats have 
        //    return View();
        //}
    }
}
