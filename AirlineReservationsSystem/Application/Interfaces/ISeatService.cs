using AirlineReservationsSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirlineReservationsSystem.Application.Interfaces
{
    public interface ISeatService
    {
        Task<IEnumerable<Seat>> GetAllSeatsAsync(); // لجلب كل المقاعد
        Task<Seat> GetSeatByIdAsync(int seatId); // لجلب مقعد معين بواسطة الـ ID
        Task<IEnumerable<Seat>> GetAvailableSeatsAsync(int flightId); // لجلب المقاعد المتاحة لرحلة معينة
        Task<bool> BookSeatAsync(int seatId, string userId); // لحجز مقعد
        Task<bool> ReleaseSeatAsync(int seatId); // لتحرير مقعد
    }
}
