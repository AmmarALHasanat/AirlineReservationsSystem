using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class TravelRoute
    {
        public int TravelRouteId { get; set; }

        [Required]
        [MaxLength(3)]
        public string Origin { get; set; }

        [Required]
        [MaxLength(3)]
        public string Destination { get; set; }

        public string EstimatedTime { get; set; }

        public virtual ICollection<Flight> Flights { get; set; } 
    }
}
