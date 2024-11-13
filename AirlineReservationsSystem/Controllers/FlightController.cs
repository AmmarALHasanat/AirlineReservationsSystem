using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
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

        // عرض جميع الرحلات
        public async Task<IActionResult> Index()
        {
            var flights = await _flightService.GetAllFlightsAsync();
            return View(flights);
        }

        // عرض صفحة إضافة رحلة جديدة
        public IActionResult Create()
        {
            return View();
        }

        // إضافة رحلة جديدة
        [HttpPost]
        public async Task<IActionResult> Create(Flight flight)
        {
            if (ModelState.IsValid)
            {
                await _flightService.CreateFlightAsync(flight);
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // عرض صفحة تعديل رحلة
        public async Task<IActionResult> Edit(int id)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // تحديث الرحلة
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Flight flight)
        {
            if (id != flight.FlightId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _flightService.UpdateFlightAsync(flight);
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // حذف رحلة
        public async Task<IActionResult> Delete(int id)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            await _flightService.DeleteFlightAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
