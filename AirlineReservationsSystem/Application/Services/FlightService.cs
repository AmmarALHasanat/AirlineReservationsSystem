using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Infrastructure.Data;

namespace AirlineReservationsSystem.Application.Services
{
    public class FlightService: IFlightService
    {
        private readonly AppDbContext _context;
        public FlightService(AppDbContext context) { _context = context; }

        // ملاحظة لا يمكن البحق عن رحلة تاريخها قبل 24 ساعة من الرحلة 
        // index البجث باستخدام التاربخ بالاضافة الى نقطة الباية و الوجهة

        // create or update fligth by admin roule only 
       
    }
}
