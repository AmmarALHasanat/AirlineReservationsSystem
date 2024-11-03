using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Models;
using Microsoft.AspNetCore.Identity;


namespace AirlineReservationsSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task<SignInResult> LoginAsync(string email, string password, bool rememberMe);
        Task<IdentityResult> RegisterAsync(User user, string password);
        Task LogoutAsync();
    }
}
