using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class Flight
    {
        public int FlightId { get; set; }

        [Required]
        public string FlightNumber { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }


        [Required]
        [ForeignKey("Airplane")]
        public int AirplaneId { get; set; }

        [Required]
        [ForeignKey("TravelRoute")]
        public int TravelRouteId { get; set; }

        public virtual Airplane Airplane { get; set; }
        public virtual TravelRoute Route { get; set; }

        // Navigation Properties
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public virtual ICollection<FlightSeat> FlightSeats { get; set; } = new List<FlightSeat>();
    }
}
