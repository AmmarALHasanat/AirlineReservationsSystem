using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public int AirplaneId { get; set; }
        public int RouteId { get; set; }

        // Navigation Properties
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public virtual ICollection<FlightSeat> FlightSeats { get; set; } = new List<FlightSeat>();
    }
}
