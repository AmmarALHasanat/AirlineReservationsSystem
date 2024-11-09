using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Domain.Enums;
using AirlineReservationsSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AirlineReservationsSystem.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly AppDbContext _context;

        public PaymentService(AppDbContext context)
        {
            _context = context;
        }

        // إنشاء دفعة جديدة
        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        // استرجاع تفاصيل الدفع باستخدام paymentId
        public async Task<Payment> GetPaymentDetailsAsync(int paymentId)
        {
            return await _context.Payments
                .FirstOrDefaultAsync(p => p.PaymentId == paymentId);
        }

        // إلغاء الدفع باستخدام paymentId
        public async Task<bool> CancelPaymentAsync(int paymentId)
        {
            var payment = await _context.Payments
                .FirstOrDefaultAsync(p => p.PaymentId == paymentId);

            if (payment == null)
                return false;

            // تحويل الـ string إلى قيمة الـ enum
            payment.Status = PaymentStatus.Cancelled; // استخدم enum بدل من string
            await _context.SaveChangesAsync();

            return true;
        }

        // تحديث حالة الدفع (مثلاً بعد تأكيد الدفع)
        public async Task<bool> UpdatePaymentStatusAsync(int paymentId, string status)
        {
            var payment = await _context.Payments
                .FirstOrDefaultAsync(p => p.PaymentId == paymentId);

            if (payment == null)
                return false;

            // تحويل الـ string إلى قيمة الـ enum باستخدام Enum.TryParse
            if (Enum.TryParse(status, true, out PaymentStatus paymentStatus)) // مع إضافة true لتجاهل حالة الأحرف
            {
                payment.Status = paymentStatus;  // تعيين الـ enum
                await _context.SaveChangesAsync();
                return true;
            }

            return false; // إذا لم يتم التعرف على القيمة المُمررة
        }

    }
}
