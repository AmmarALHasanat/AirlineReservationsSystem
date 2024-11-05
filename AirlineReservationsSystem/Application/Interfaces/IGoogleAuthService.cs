using Microsoft.AspNetCore.Mvc;

namespace AirlineReservationsSystem.Application.Interfaces
{
    public interface IGoogleAuthService
    {
        IActionResult InitiateGoogleLogin(string redirectUrl);
        Task<IActionResult> HandleGoogleResponse(HttpContext httpContext);
    }
}
