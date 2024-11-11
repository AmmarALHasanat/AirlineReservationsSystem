using AirlineReservationsSystem.Domain.Entities;

namespace AirlineReservationsSystem.Application.Interfaces
{
    public interface IAirplaneService
    {
        Task<List<Airplane>> GetAllAirplanesAsync();
    }
}
