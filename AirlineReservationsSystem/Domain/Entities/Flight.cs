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
        [MaxLength(10)] // يمكن ضبط الطول حسب تنسيق أرقام الرحلات
        public string FlightNumber { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }


        [Required]
        [ForeignKey("Airplane")]
        public int AirplaneId { get; set; }

        [Required]
        [ForeignKey("Route")]
        public int RouteId { get; set; }

        public virtual Airplane Airplane { get; set; }
        public virtual Route Route { get; set; }

        // Navigation Properties
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public virtual ICollection<FlightSeat> FlightSeats { get; set; } = new List<FlightSeat>();
    }
}
