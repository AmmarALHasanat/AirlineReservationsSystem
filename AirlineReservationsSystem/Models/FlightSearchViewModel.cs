using AirlineReservationsSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace AirlineReservationsSystem.Models
{
    public enum TripType
    {
        OneWay,
        RoundTrip
    }
    public class FlightSearchViewModel
    {
        [Required(ErrorMessage = "The departure location is required.")]
        public string From { get; set; }

        [Required(ErrorMessage = "The destination location is required.")]
        public string To { get; set; }

        [Required(ErrorMessage = "The departure date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Departure Date")]
        [FutureDate(ErrorMessage = "The departure date must be in the future.")]
        public DateTime? DepartureDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Return Date (Optional)")]
        public DateTime? ReturnDate { get; set; }

        [Required(ErrorMessage = "Please select the trip type.")]
        public string TripType { get; set; } // "OneWay" or "RoundTrip"

        public List<Flight> AvailableFlights { get; set; }
    }

    // Custom validation attribute to ensure the date is in the future
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date > DateTime.Now;
            }
            return true;
        }
    }
}
