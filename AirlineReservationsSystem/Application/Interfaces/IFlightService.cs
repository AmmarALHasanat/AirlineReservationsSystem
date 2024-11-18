using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Domain.Enums;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirlineReservationsSystem.Application.Interfaces
{
    public interface IFlightService
    {


        Task CreateFlightAsync(Flight flight, Dictionary<SeatType, decimal> prices);                // إنشاء رحلة جديدة
        //Task UpdateFlightAsync(Flight flight);                // تحديث بيانات رحلة
        //Task DeleteFlightAsync(int flightId);                 // حذف رحلة بناءً على الـ ID
        Task<Flight?> GetFlightByIdAsync(int flightId);   
        Task<List<Flight>> GetAllFlightsAsync();
        Task<List<Flight>> GetAvailableFlightsAsync(string from, string to, DateTime? departureDate, DateTime? returnDate, string tripType);

    }
}
