using AirlineReservationsSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirlineReservationsSystem.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> CreatePaymentAsync(Payment payment);
        Task<Payment> GetPaymentDetailsAsync(int paymentId);
        Task<bool> CancelPaymentAsync(int paymentId);
        Task<bool> UpdatePaymentStatusAsync(int paymentId, string status);
    }
}
