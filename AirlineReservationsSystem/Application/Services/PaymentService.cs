using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Infrastructure.Data;

namespace AirlineReservationsSystem.Application.Services
{
    public class PaymentService: IPaymentService
    {
        private readonly AppDbContext _context;
        public PaymentService(AppDbContext context) { _context = context; }
    }
}
