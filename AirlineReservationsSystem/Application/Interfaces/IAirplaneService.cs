using AirlineReservationsSystem.Domain.Entities;

namespace AirlineReservationsSystem.Application.Interfaces
{
    public interface IAirplaneService
    {
        Task<List<Airplane>> GetAllAirplanesAsync();
        Task AddAirplaneAsync(Airplane airplane);
        Task<Airplane?> GetAirplaneByIdAsync(int id);
        Task<Airplane?> UpdateAirplaneAsync(Airplane airplane); 

    }
}
