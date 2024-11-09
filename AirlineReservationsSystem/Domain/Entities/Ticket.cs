using AirlineReservationsSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }

        // Foreign keys for ticket
        [Required]
        [ForeignKey("Flight")]
        public int FlightId { get; set; }
        [Required]
        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        
        [Required(ErrorMessage = "نوع المقعد مطلوب.")]
        public string SeatType { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "يجب أن يكون سعر التذكرة أكبر من صفر.")]
        public decimal Price { get; set; }

        [Required]
        public TicketStatus Status { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual User User { get; set; }
    }

}
