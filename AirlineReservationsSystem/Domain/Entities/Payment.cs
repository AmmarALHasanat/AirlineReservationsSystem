using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; } // معرّف فريد للدفع

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "يجب أن يكون المبلغ أكبر من 0.")]
        public decimal Amount { get; set; } // المبلغ المدفوع

        [Required]
        public DateTime PaymentDate { get; set; } = DateTime.Now; // تاريخ الدفع

        [Required]
        [MaxLength(50)]
        public string PaymentMethod { get; set; } // طريقة الدفع (مثل بطاقة ائتمان، PayPal، إلخ)

        public int BookingId { get; set; } // معرّف الحجز المرتبط بالدفع

        // الربط مع كلاس Booking
        public Booking Booking { get; set; }
    }
}
