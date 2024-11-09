using AirlineReservationsSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirlineReservationsSystem.Application.Interfaces
{
    public interface IFlightService
    {
        Task CreateFlightAsync(Flight flight);                // إنشاء رحلة جديدة
        Task UpdateFlightAsync(Flight flight);                // تحديث بيانات رحلة
        Task DeleteFlightAsync(int flightId);                 // حذف رحلة بناءً على الـ ID
        Task<Flight> GetFlightByIdAsync(int flightId);        // الحصول على رحلة واحدة بناءً على الـ ID
        Task<List<Flight>> GetAllFlightsAsync();              // الحصول على جميع الرحلات
    }
}
