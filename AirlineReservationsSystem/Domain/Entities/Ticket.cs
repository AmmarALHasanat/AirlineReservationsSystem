using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; } // المعرف الفريد للتذكرة
        [Required]
        [ForeignKey("Flight")]
        public int FlightId { get; set; }
        [Required]
        [ForeignKey("Booking")]
        public int BookingId { get; set; } // مفتاح خارجي للحجز

        [Required(ErrorMessage = "نوع المقعد مطلوب.")]
        public string SeatType { get; set; } // رقم المقعد

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "يجب أن يكون سعر التذكرة أكبر من صفر.")]
        public decimal Price { get; set; } // سعر التذكرة

        [Required]
        public TicketStatus Status { get; set; } // الحالة (محجوز، ملغي)

        public virtual Booking Booking { get; set; }
        public virtual Flight Flight { get; set; }
    }

    public enum TicketStatus
    {
        Reserved, // محجوز
        Canceled, // ملغي
        CheckedIn // تسجيل الوصول
    }
}
