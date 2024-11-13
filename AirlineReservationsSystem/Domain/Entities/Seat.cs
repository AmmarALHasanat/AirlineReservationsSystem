using AirlineReservationsSystem.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class Seat
    {
        public int SeatId { get; set; }
     
        [Required()]
        [Range(0, int.MaxValue, ErrorMessage = "Total number of seats must be greater than or equal to 0.")]
        public int TotalNumber { get; set; }
        public SeatType Class { get; set; }

        [Required]
        [ForeignKey("Airplane")]
        public int AirplaneId { get; set; }
        public virtual Airplane Airplane { get; set; }

        public virtual ICollection<FlightSeat> FlightSeats { get; set; } = new List<FlightSeat>();
    }
}
