using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AirlineReservationsSystem.Application.Services
{
    public class GoogleAuthService : IGoogleAuthService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public GoogleAuthService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult InitiateGoogleLogin(string redirectUrl)
        {
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return new ChallengeResult(GoogleDefaults.AuthenticationScheme, properties);
        }

        public async Task<IActionResult> HandleGoogleResponse(HttpContext httpContext)
        {
            var result = await httpContext.AuthenticateAsync(IdentityConstants.ExternalScheme);

            if (result?.Principal == null)
            {
                return new RedirectToActionResult("Login", "Account", null);
            }

            var email = result.Principal.FindFirstValue(ClaimTypes.Email);
            var name = result.Principal.FindFirstValue(ClaimTypes.Name);

            var user = await userManager.FindByEmailAsync(email!);
            if (user == null)
            {
                user = new User { UserName = email, Email = email, FullName = name};
                var createResult = await userManager.CreateAsync(user);

                if (!createResult.Succeeded)
                {
                    return new RedirectToActionResult("Login", "Account", null);
                }
            }

            await signInManager.SignInAsync(user, isPersistent: false);
            await httpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return new RedirectToActionResult("Index", "Home", null);
        }
    }
}
