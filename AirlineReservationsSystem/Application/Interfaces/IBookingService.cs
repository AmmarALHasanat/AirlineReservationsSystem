using AirlineReservationsSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirlineReservationsSystem.Application.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookingsByFlightAsync(int flightId);
        Task<IEnumerable<Booking>> GetAllBookingsByUserIdAsync(int userId);
        Task CreateBookingAsync(Booking booking);
        Task UpdateBookingAsync(Booking booking);
    }
}
