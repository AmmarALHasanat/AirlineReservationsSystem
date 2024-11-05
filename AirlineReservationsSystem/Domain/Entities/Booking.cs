namespace AirlineReservationsSystem.Domain.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }

        // تعديل UserId ليكون من نوع string
        public string UserId { get; set; }  // تم تغييره إلى string

        public int FlightId { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; } // مثل "Confirmed" أو "Canceled"

        // Navigation Properties
        public virtual User User { get; set; }
        public virtual Flight Flight { get; set; }
    }
    public class UserViewModel
    {
        public string FullName { get; set; } // الاسم الكامل للمستخدم
    }
    public enum BookingStatus
    {
        Confirmed,
        Canceled,
        Pending
    }
}
