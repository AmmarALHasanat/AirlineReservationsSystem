using AirlineReservationsSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace AirlineReservationsSystem.Models
{
    public class FlightSearchViewModel
    {
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }

        public DateTime? DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string TripType { get; set; }
        public List<Flight> AvailableFlights { get; set; }
    }
}
