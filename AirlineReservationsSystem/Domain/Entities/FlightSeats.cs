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
        public virtual Seat Seat { get; set; } 
        [Required]
        [ForeignKey("Flight")]
        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; } 


        [Required]
        [Range(0.01, double.MaxValue)] 
        public float SeatPrice { get; set; }

        [Required]
        [Range(0, 200)]
        public int AvailableSeats { get; set; }
    }
}
