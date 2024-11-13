using AirlineReservationsSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirlineReservationsSystem.Application.Interfaces
{
    public interface ITravelRouteService
    {
        Task<IEnumerable<TravelRoute>> GetAllRoutesAsync();

        Task<TravelRoute> GetRouteByIdAsync(int routeId);

        Task<bool> AddRouteAsync(TravelRoute route);

    }
}
