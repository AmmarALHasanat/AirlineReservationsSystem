using AirlineReservationsSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace AirlineReservationsSystem.Application.Interfaces
{
    public interface ITravelRouteService
    {
        Task<List<TravelRoute>> GetAllRoutesAsync();
        IPagedList<TravelRoute> GetPaginatedRoutesAsync(int pageNumber, int pageSize);

        Task<TravelRoute> GetRouteByIdAsync(int routeId);

        Task<bool> AddRouteAsync(TravelRoute route);

    }
}
