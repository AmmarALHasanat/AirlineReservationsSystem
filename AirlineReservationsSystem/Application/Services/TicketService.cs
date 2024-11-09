using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Infrastructure.Data;

namespace AirlineReservationsSystem.Application.Services
{
    public class TicketService: ITicketService
    {
        private readonly AppDbContext _context;
        public TicketService(AppDbContext context) { _context = context; }
    }
}
