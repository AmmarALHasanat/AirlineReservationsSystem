using System.ComponentModel.DataAnnotations;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class TravelRoute
    {
        [Key]
        public int RouteId { get; set; }

        [Required(ErrorMessage = "يجب إدخال نقطة البداية.")]
        [MaxLength(100)]
        public string Origin { get; set; } 

        [Required(ErrorMessage = "يجب إدخال الوجهة.")]
        [MaxLength(100)]
        public string Destination { get; set; }

        [Required(ErrorMessage = "يجب إدخال الوقت المقدر.")]
        [MaxLength(50)]
        public string EstimatedTime { get; set; } 

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
