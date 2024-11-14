using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Extensions;

namespace AirlineReservationsSystem.Application.Services
{
    public class TravelRouteService : ITravelRouteService
    {
        private readonly AppDbContext _context;

        public TravelRouteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TravelRoute>> GetAllRoutesAsync()
        {
            return await _context.Routes.ToListAsync();
        }

        public IPagedList<TravelRoute> GetPaginatedRoutesAsync(int pageNumber=1, int pageSize=10)
        {
            var routes = _context.Routes.AsQueryable();
            return routes.ToPagedList(pageNumber, pageSize);
        }

        public async Task<TravelRoute> GetRouteByIdAsync(int routeId)
        {
            return await _context.Routes .FirstOrDefaultAsync(r => r.TravelRouteId == routeId);  // استخدام Routes هنا
        }

        public async Task<bool> AddRouteAsync(TravelRoute route)
        {
            await _context.Routes.AddAsync(route);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateRouteAsync(TravelRoute route)
        {
            var existingRoute = await _context.Routes
                .FirstOrDefaultAsync(r => r.TravelRouteId == route.TravelRouteId);

            if (existingRoute == null)
            {
                return false;
            }

            existingRoute.Origin = route.Origin;
            existingRoute.Destination = route.Destination;
            existingRoute.EstimatedTime = route.EstimatedTime;

            _context.Routes.Update(existingRoute);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRouteAsync(int routeId)
        {
            var route = await _context.Routes
                .FirstOrDefaultAsync(r => r.TravelRouteId == routeId);

            if (route == null)
            {
                return false;
            }

            _context.Routes.Remove(route);  // استخدام Routes هنا
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
