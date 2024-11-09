﻿using AirlineReservationsSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationsSystem.Controllers
{
    public class AirplaneController : Controller
    {
        private readonly IAirplaneeService _airplaneService;

        public AirplaneController(IAirplaneeService airplaneService)
        {
            _airplaneService = airplaneService;
        }

        // عرض الطائرات في صفحة Index
        public async Task<IActionResult> Index()
        {
            var airplanes = await _airplaneService.GetAllAirplanesAsync();
            return View(airplanes); // تمرير البيانات إلى الواجهة
        }
    }


}
