using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AirlineReservationsSystem.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // إنشاء دفعة جديدة
        [HttpPost]
        public async Task<IActionResult> CreatePayment(Payment payment)
        {
            if (ModelState.IsValid)
            {
                var createdPayment = await _paymentService.CreatePaymentAsync(payment);
                return RedirectToAction("PaymentDetails", new { paymentId = createdPayment.PaymentId });
            }
            return View(payment);
        }

        // عرض تفاصيل الدفع
        [HttpGet]
        public async Task<IActionResult> PaymentDetails(int paymentId)
        {
            var payment = await _paymentService.GetPaymentDetailsAsync(paymentId);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        // تحديث حالة الدفع
        [HttpPost]
        public async Task<IActionResult> UpdatePaymentStatus(int paymentId, string status)
        {
            var success = await _paymentService.UpdatePaymentStatusAsync(paymentId, status);
            if (!success)
            {
                return NotFound();
            }
            return RedirectToAction("PaymentDetails", new { paymentId });
        }

        // إلغاء الدفع
        [HttpPost]
        public async Task<IActionResult> CancelPayment(int paymentId)
        {
            var success = await _paymentService.CancelPaymentAsync(paymentId);
            if (!success)
            {
                return NotFound();
            }
            return RedirectToAction("PaymentDetails", new { paymentId });
        }
    }
}
