using AirlineReservationsSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AirlineReservationsSystem.Infrastructure.Middleware
{
    public class RoleRedirectMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleRedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userManager = context.RequestServices.GetRequiredService<UserManager<User>>();
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId != null)
                {
                    var user = await userManager.FindByIdAsync(userId);

                    if (user != null)
                    {
                        //var role = (await userManager.GetRolesAsync(user)).FirstOrDefault();
                        var isAdmin = await userManager.IsInRoleAsync(user, "Admin");
                        //var isUser = await userManager.IsInRoleAsync(user, "User");

                        var path = context.Request.Path;

                        if (path.StartsWithSegments("/Dashboard") && !isAdmin)
                        {
                            context.Response.Redirect("/Home");
                            return;
                        }

                        if (!path.StartsWithSegments("/Dashboard") && isAdmin)
                        {
                            context.Response.Redirect("/Dashboard");
                            return;
                        }
                    }
                }
            }

            await _next(context);
        }
    }
}
