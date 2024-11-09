using AirlineReservationsSystem.Domain.Entities;

namespace AirlineReservationsSystem.Application.Interfaces
{
    public interface ITicketService
    {
        //New Ticket
        Task<Ticket> IssueTicketAsync(int bookingId, string userId);

        // جلب جميع التذاكر للمستخدم
        Task<IEnumerable<Ticket>> GetUserTicketsAsync(string userId);

        // ticket Details
        Task<Ticket> GetTicketByIdAsync(int ticketId);

        // ignore ticket
        Task<bool> CancelTicketAsync(int ticketId);

        // update ticket status
        Task<bool> UpdateTicketStatusAsync(int ticketId, string status);
    }
}
