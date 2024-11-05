using AirlineReservationsSystem.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; } // المعرف الفريد للمقعد

        [Required(ErrorMessage = "رقم المقاعد مطلوب في الفئة مطلوب.")]
        [MaxLength(10)]
        public int SeatNumber { get; set; } //عدد المقاعد من نوع معين في الطائرة مثل class A have 10 seats
        public ClassType Class { get; set; } // فشة المقعد 
        //[RegularExpression(@"^[1-9]\d*[A-Z]?$", ErrorMessage = "رقم المقعد غير صالح. يجب أن يكون بتنسيق صحيح (مثل 1A، 2B).")]

        public virtual Airplane Airplane { get; set; }

        // خصائص إضافية حسب الحاجة
        public ICollection<FlightSeat> FlightSeats { get; set; } = new List<FlightSeat>();
    }
}
