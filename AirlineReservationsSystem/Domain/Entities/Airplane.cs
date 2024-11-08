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
        public int Capacity { get; set; }


        public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
        public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

    }
}
