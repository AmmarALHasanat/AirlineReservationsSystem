using Microsoft.AspNetCore.Identity;
using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservationsSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        public UserService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        public async Task<SignInResult> LoginAsync(string email, string password,bool rememberMe)
        {
            
            return await signInManager.PasswordSignInAsync(
                email,
                password,
                rememberMe,
                lockoutOnFailure: false); ;
        }

        public async Task<IdentityResult> RegisterAsync(User user, string password)
        {
            var existingUserWithPhone = await userManager.Users
                .AnyAsync(u => u.PhoneNumber == user.PhoneNumber);

            if (existingUserWithPhone)
            {
                // Return a failed result with an appropriate error message
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "DuplicatePhoneNumber",
                    Description = "A user with this phone number already exists."
                });
            }

            var result = await userManager.CreateAsync(user, password);
            
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User"); 
                await signInManager.SignInAsync(user, false);
            }
            return result;
            
        }
        public async Task LogoutAsync() => await signInManager.SignOutAsync();

    }
}
