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
    public class AirplaneController : Controller
    {
        private readonly IAirplaneService _airplaneService;

        public AirplaneController(IAirplaneService airplaneService)
        {
            _airplaneService = airplaneService;
        }

        // GET: Dashboard/Airplane/Index
        public async Task<IActionResult> Index()
        {
            var airplanes = await _airplaneService.GetAllAirplanesAsync();
            return View(airplanes);
        }

        // GET: Dashboard/Airplane/Create
        public IActionResult Create()
        {
            var viewModel = new AirplaneCreateViewModel();

            // Populate the Seats list with available seat types
            foreach (SeatType seatType in Enum.GetValues(typeof(SeatType)))
            {
                viewModel.Seats.Add(new SeatInputModel { Class = seatType, TotalNumber = 0 });
            }

            return View(viewModel);
        }

        // POST: Dashboard/Airplane/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AirplaneCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int totalSeats = viewModel.Seats.Sum(seat => seat.TotalNumber);


                if (totalSeats != viewModel.airplane.Capacity)
                {
                    ModelState.AddModelError("", "The total number of seats across all classes must equal the airplane's capacity.");
                    return View(viewModel);
                }

                var airplane = new Airplane
                {
                    Model = viewModel.airplane.Model,
                    Capacity = viewModel.airplane.Capacity,
                    Seats = viewModel.Seats.Select(seat => new Seat
                    {
                        Class = seat.Class,
                        TotalNumber = seat.TotalNumber
                    }).ToList()
                };

                await _airplaneService.AddAirplaneAsync(airplane);

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        // GET: Dashboard/Airplane/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var airplane = await _airplaneService.GetAirplaneByIdAsync(id);

            if (airplane == null)
            {
                return NotFound();
            }
            return View(airplane);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var airplane = await _airplaneService.GetAirplaneByIdAsync(id);
             
            if (airplane == null)
            {
                return NotFound();
            }

            var viewModel = new AirplaneUpdateViewModel
            {
                Airplane = airplane,
                Seats = airplane.Seats.Select(seat => new SeatupdateModel
                {
                    SeatId = seat.SeatId,
                    Class = seat.Class,
                    TotalNumber = seat.TotalNumber
                }).ToList()
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AirplaneUpdateViewModel viewModel)
        {
            if (id != viewModel.Airplane.AirplaneId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                int totalSeats = viewModel.Seats.Sum(seat => seat.TotalNumber);

                if (totalSeats != viewModel.Airplane.Capacity)
                {
                    ModelState.AddModelError("", "The total number of seats across all classes must equal the airplane's capacity.");
                    return View(viewModel);
                }
                viewModel.Airplane.Seats = viewModel.Seats.Select(seat => new Seat
                {
                    SeatId = seat.SeatId,
                    Class = seat.Class,
                    TotalNumber = seat.TotalNumber
                }).ToList();

                var updatedAirplane = await _airplaneService.UpdateAirplaneAsync(viewModel.Airplane);

                if (updatedAirplane == null)
                {
                    return NotFound(); 
                }

                return RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                // Collect all validation error messages
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                               .Select(e => e.ErrorMessage)
                                               .ToList();

                // Print or log each error message
                foreach (var error in errors)
                {
                    Console.WriteLine(error); // You can replace this with a logger if needed
                }
            }



            return View(viewModel);
        }

    }
}
