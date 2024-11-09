using AirlineReservationsSystem.Domain.Entities;

namespace AirlineReservationsSystem.Application.Interfaces
{
    public interface IAirplaneeService
    {
        Task<List<Airplane>> GetAllAirplanesAsync();
    }
}
