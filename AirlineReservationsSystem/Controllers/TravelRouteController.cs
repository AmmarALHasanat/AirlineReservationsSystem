using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationsSystem.Controllers
{
    public class TravelRouteController : Controller
    {
        private readonly ITravelRouteService _travelRouteService;

        public TravelRouteController(ITravelRouteService travelRouteService)
        {
            _travelRouteService = travelRouteService;
        }

        // عرض جميع المسارات
        public async Task<IActionResult> Index()
        {
            var routes = await _travelRouteService.GetAllRoutesAsync();
            return View(routes);
        }

        // عرض تفاصيل مسار معين
        public async Task<IActionResult> Details(int id)
        {
            var route = await _travelRouteService.GetRouteByIdAsync(id);
            if (route == null)
            {
                return NotFound();
            }
            return View(route);
        }

        // صفحة إضافة مسار جديد
        public IActionResult Create()
        {
            return View();
        }

        // إضافة مسار جديد
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TravelRoute route)
        {
            if (ModelState.IsValid)
            {
                await _travelRouteService.AddRouteAsync(route);
                return RedirectToAction(nameof(Index));
            }
            return View(route);
        }

        // صفحة تعديل مسار
        public async Task<IActionResult> Edit(int id)
        {
            var route = await _travelRouteService.GetRouteByIdAsync(id);
            if (route == null)
            {
                return NotFound();
            }
            return View(route);
        }

        // تعديل مسار
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TravelRoute route)
        {
            if (id != route.RouteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _travelRouteService.UpdateRouteAsync(route);
                return RedirectToAction(nameof(Index));
            }
            return View(route);
        }

        // حذف مسار
        public async Task<IActionResult> Delete(int id)
        {
            var route = await _travelRouteService.GetRouteByIdAsync(id);
            if (route == null)
            {
                return NotFound();
            }
            return View(route);
        }

        // تنفيذ حذف مسار
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _travelRouteService.DeleteRouteAsync(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
