using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirlineReservationsSystem.Application.Services
{
    public class TravelRouteService : ITravelRouteService
    {
        private readonly AppDbContext _context;

        public TravelRouteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TravelRoute>> GetAllRoutesAsync()
        {
            return await _context.Routes.ToListAsync();  // استخدام Routes هنا
        }

        // جلب مسار معين حسب الـ ID
        public async Task<TravelRoute> GetRouteByIdAsync(int routeId)
        {
            return await _context.Routes .FirstOrDefaultAsync(r => r.RouteId == routeId);  // استخدام Routes هنا
        }

        // إضافة مسار جديد
        public async Task<bool> AddRouteAsync(TravelRoute route)
        {
            await _context.Routes.AddAsync(route);  // استخدام Routes هنا
            await _context.SaveChangesAsync();
            return true;
        }

        // تحديث مسار موجود
        public async Task<bool> UpdateRouteAsync(TravelRoute route)
        {
            var existingRoute = await _context.Routes
                .FirstOrDefaultAsync(r => r.RouteId == route.RouteId);

            if (existingRoute == null)
            {
                return false;
            }

            existingRoute.Origin = route.Origin;
            existingRoute.Destination = route.Destination;
            existingRoute.EstimatedTime = route.EstimatedTime;

            _context.Routes.Update(existingRoute);  // استخدام Routes هنا
            await _context.SaveChangesAsync();
            return true;
        }

        // حذف مسار
        public async Task<bool> DeleteRouteAsync(int routeId)
        {
            var route = await _context.Routes
                .FirstOrDefaultAsync(r => r.RouteId == routeId);

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
