using AirlineReservationsSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace AirlineReservationsSystem.Infrastructure.Data
{
    public static class RoleSeeder
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Admin", "User" };
            foreach (var roleName in roleNames)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

        }

        public static async Task SeedAdminsAsync(IServiceProvider serviceProvider)
        {
            var _userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var adminUsers = new List<(string Email, string Password, string FullName)>
            {
                ("ammarabed13@gmail.com", "Admin@123", "Ammar AL-Hasanat"),
                ("thabetmahmoud238@gmail.com", "Admin@123", "Mahmoud Azzam")
            };

            foreach (var admin in adminUsers)
            {
                await EnsureAdminAsync(_userManager, admin.Email, admin.Password, admin.FullName);
            }

        }


        private static async Task EnsureAdminAsync(UserManager<User> userManager, string email, string password, string fullName)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FullName = fullName,
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true,
                };
                await userManager.CreateAsync(user, password);
            }

            if (!await userManager.IsInRoleAsync(user, "Admin"))
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }

}
