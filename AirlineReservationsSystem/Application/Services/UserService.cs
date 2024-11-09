using Microsoft.AspNetCore.Identity;
using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using System.Threading.Tasks;

namespace AirlineReservationsSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Login method
        public async Task<SignInResult> LoginAsync(string email, string password, bool rememberMe)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return SignInResult.Failed; // Failed to find user
            }

            return await _signInManager.PasswordSignInAsync(user, password, rememberMe, false);
        }

        // Register method
        public async Task<IdentityResult> RegisterAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }

        // Logout method
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
