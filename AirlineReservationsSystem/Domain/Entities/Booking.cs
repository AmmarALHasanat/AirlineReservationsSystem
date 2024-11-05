using AirlineReservationsSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace AirlineReservationsSystem.Domain.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }


        public DateTime BookingDate { get; set; }
        public BookingStatus Status { get; set; }

        // Navigation Properties
        public virtual User User { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
    public class UserViewModel
    {
        public string FullName { get; set; } // الاسم الكامل للمستخدم
    }

}
