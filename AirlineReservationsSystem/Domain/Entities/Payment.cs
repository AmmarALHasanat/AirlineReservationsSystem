using AirlineReservationsSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; } 

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "يجب أن يكون المبلغ أكبر من 0.")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; } = DateTime.Now; 

        [Required]
        public PaymentMethod Type { get; set; }

        public PaymentStatus Status { get; set; }

        [Required]
        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        public virtual Booking Booking { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
