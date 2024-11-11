using AirlineReservationsSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AirlineReservationsSystem.Infrastructure
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
            var adminEmail = "ammarabed13@gmail.com";
            var adminPassword = "Admin@123";

            var adminUser = await _userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new User
                {
                    FullName = "Ammar AL-Hasanat",
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                };
                await _userManager.CreateAsync(adminUser, adminPassword);
            }

            if (!await _userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                await _userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }

}
