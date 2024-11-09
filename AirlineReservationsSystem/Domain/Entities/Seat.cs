using AirlineReservationsSystem.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class Seat
    {
        public int SeatId { get; set; }

        [Required(ErrorMessage = "رقم المقاعد مطلوب في الفئة مطلوب.")]
        [MaxLength(10)]
        public int SeatNumber { get; set; }
        public ClassType Class { get; set; }
        //[RegularExpression(@"^[1-9]\d*[A-Z]?$", ErrorMessage = "رقم المقعد غير صالح. يجب أن يكون بتنسيق صحيح (مثل 1A، 2B).")]

        [Required]
        [ForeignKey("Airplane")]
        public int AirplaneId { get; set; }
        public virtual Airplane Airplane { get; set; }
        public virtual ICollection<FlightSeat> FlightSeats { get; set; } = new List<FlightSeat>();
    }
}
