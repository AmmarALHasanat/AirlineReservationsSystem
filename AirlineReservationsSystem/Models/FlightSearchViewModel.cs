using System.ComponentModel.DataAnnotations;

namespace AirlineReservationsSystem.Models
{
    public class FlightSearchViewModel 
    {
        [Required]
        public string From { get; set; } = string.Empty;

        [Required]
        public string To { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; } 

        // Required if TripType == RoundTrip


        [Display(Name = "Return Date (Optional)")]
        public DateTime? ReturnDate { get; set; }

        [Required]
        public TripType TripType { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (TripType == TripType.RoundTrip && !ReturnDate.HasValue)
        //    {
        //        yield return new ValidationResult(
        //            "Return date is required for a round trip.",
        //            new[] { nameof(ReturnDate) }
        //        );
        //    }
        //}
    }

    public enum TripType
    {
        OneWay,
        RoundTrip
    }
}
