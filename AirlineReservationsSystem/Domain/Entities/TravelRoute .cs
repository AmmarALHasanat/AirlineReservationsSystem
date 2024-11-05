using System.ComponentModel.DataAnnotations;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class TravelRoute
    {
        [Key]
        public int RouteId { get; set; }  // تعريف المفتاح الأساسي

        [Required(ErrorMessage = "يجب إدخال نقطة البداية.")]
        [MaxLength(100)]
        public string Origin { get; set; } // نقطة البداية

        [Required(ErrorMessage = "يجب إدخال الوجهة.")]
        [MaxLength(100)]
        public string Destination { get; set; } // الوجهة

        [Required(ErrorMessage = "يجب إدخال الوقت المقدر.")]
        [MaxLength(50)]
        public string EstimatedTime { get; set; } // الوقت المقدر
    }
}
