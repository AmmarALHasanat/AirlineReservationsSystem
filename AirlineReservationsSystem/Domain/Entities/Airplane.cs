using System.ComponentModel.DataAnnotations;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class Airplane
    {
        public int AirplaneId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Total number of seats must be greater than or equal to 0.")]
        public int Capacity { get; set; } // total of number seat class E,F,B 



        public virtual List<Seat> Seats { get; set; } = new List<Seat>();
        public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

    }
}
