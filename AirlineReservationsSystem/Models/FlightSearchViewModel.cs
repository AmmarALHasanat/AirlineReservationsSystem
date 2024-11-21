using AirlineReservationsSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace AirlineReservationsSystem.Models
{
    public class FlightSearchViewModel : IValidatableObject
    {
        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }

        // Required if TripType == RoundTrip
        public DateTime? ReturnDate { get; set; }

        [Required]
        public TripType TripType { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Validate ReturnDate is required for round trips
            if (TripType == TripType.RoundTrip && !ReturnDate.HasValue)
            {
                yield return new ValidationResult(
                    "Return date is required for round trips.",
                    new[] { nameof(ReturnDate) }
                );
            }

            // Validate ReturnDate is not earlier than DepartureDate
            if (ReturnDate.HasValue && ReturnDate.Value < DepartureDate)
            {
                yield return new ValidationResult(
                    "Return date cannot be earlier than the departure date.",
                    new[] { nameof(ReturnDate) }
                );
            }
        }

         public List<Flight> AvailableFlights { get; set; }
    }

    public enum TripType
    {
        OneWay,
        RoundTrip
    }
}
