using System.ComponentModel.DataAnnotations;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; } // المعرف الفريد للتذكرة

        [Required]
        public int BookingId { get; set; } // مفتاح خارجي للحجز

        [Required(ErrorMessage = "رقم المقعد مطلوب.")]
        [MaxLength(10)]
        public string SeatNumber { get; set; } // رقم المقعد

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "يجب أن يكون سعر التذكرة أكبر من صفر.")]
        public decimal Price { get; set; } // سعر التذكرة

        [Required]
        public TicketStatus Status { get; set; } // الحالة (محجوز، ملغي)

        // العلاقة مع كلاس Booking
        public Booking Booking { get; set; }
    }

    public enum TicketStatus
    {
        Reserved, // محجوز
        Canceled, // ملغي
        CheckedIn // تسجيل الوصول
    }
}
