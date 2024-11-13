using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

using Microsoft.AspNetCore.Authentication;

//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using AirlineReservationsSystem.Application.Services;

namespace AirlineReservationsSystem.Controllers
{
    //Test Test
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IGoogleAuthService googleAuthService;


        public AccountController(IUserService userService, IGoogleAuthService googleAuthService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof (userService));
            this.googleAuthService = googleAuthService?? throw new ArgumentNullException(nameof(googleAuthService));
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var result = await userService.LoginAsync(
                loginViewModel.Email!,
                loginViewModel.Password!,
                loginViewModel.RememberMe
            );

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(loginViewModel);
        }


        public IActionResult Register() => View();


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var user = new User
            {
                FullName = registerViewModel.FullName,
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email,
                PhoneNumber = registerViewModel.PhoneNumber
            };

            var result = await userService.RegisterAsync(user, registerViewModel.Password!);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(registerViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await userService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult GoogleLogin()
        {
            var redirectUrl = Url.Action("GoogleResponse", "Account");
            return googleAuthService.InitiateGoogleLogin(redirectUrl!);
        }

        public async Task<IActionResult> GoogleResponse()
        {
            return await googleAuthService.HandleGoogleResponse(HttpContext);
        }
    }
}
