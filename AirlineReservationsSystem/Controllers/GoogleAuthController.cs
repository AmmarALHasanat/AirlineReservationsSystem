using AirlineReservationsSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationsSystem.Controllers
{
    public class GoogleAuthController : Controller
    {
        private readonly IGoogleAuthService _googleAuthService;

        public GoogleAuthController(IGoogleAuthService googleAuthService)
        {
            _googleAuthService = googleAuthService;
        }

        // بدء عملية تسجيل الدخول عبر Google
        public IActionResult Login(string returnUrl = null)
        {
            return _googleAuthService.InitiateGoogleLogin(returnUrl);
        }

        // التعامل مع الاستجابة بعد تسجيل الدخول
        public async Task<IActionResult> GoogleResponse()
        {
            return await _googleAuthService.HandleGoogleResponse(HttpContext);
        }
    }
}
