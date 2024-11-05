using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class FlightSeat
    {
        [Key]
        public int FlightSeatId { get; set; }

        [Required]
        [ForeignKey("Seat")]
        public int SeatId { get; set; }
        public Seat Seat { get; set; } // علاقة مع كلاس Seat

        [Required]
        [ForeignKey("Flight")]
        public int FlightId { get; set; }
        public Flight Flight { get; set; } // علاقة مع كلاس Flight

        [Required]
        [Range(0.01, double.MaxValue)] // تحديد الحد الأدنى للسعر
        public float SeatPrice { get; set; }

        [Required]
        [Range(0, 200)] // تحديد الحد الأقصى المتاح للمقاعد
        public int AvailableSeats { get; set; }
    }
}
