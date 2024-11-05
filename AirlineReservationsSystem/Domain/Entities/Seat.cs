using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; } // المعرف الفريد للمقعد

        [Required(ErrorMessage = "رقم المقعد مطلوب.")]
        [MaxLength(10)]
        [RegularExpression(@"^[1-9]\d*[A-Z]?$", ErrorMessage = "رقم المقعد غير صالح. يجب أن يكون بتنسيق صحيح (مثل 1A، 2B).")]
        public string SeatNumber { get; set; } // رقم المقعد (مثل "1A")

        public bool IsAvailable { get; set; } = true; // لتحديد ما إذا كان المقعد متاحًا، القيمة الافتراضية: متاح

        public int FlightId { get; set; } // معرف الرحلة المرتبط

        // خصائص إضافية حسب الحاجة
        public ICollection<FlightSeat> FlightSeats { get; set; } = new List<FlightSeat>();
    }
}
