using AirlineReservationsSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirlineReservationsSystem.Application.Interfaces
{
    public interface IBookingService
    {
        Task<List<Booking>> GetAllBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int bookingId);
        Task CreateBookingAsync(Booking booking);
        Task UpdateBookingAsync(Booking booking);
        Task DeleteBookingAsync(int bookingId);

    }

}
