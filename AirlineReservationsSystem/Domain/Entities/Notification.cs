using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; } // لإنشاء علاقة مع جدول المستخدمين

        [Required]
        [MaxLength(500)] // تحديد الحد الأقصى لطول الرسالة
        public string Message { get; set; }

        [Required]
        public DateTime NotificationDate { get; set; }

        [Required]
        public NotificationStatus Status { get; set; } = NotificationStatus.Unread; // القيمة الافتراضية
    }

    public enum NotificationStatus
    {
        Read,
        Unread
    }
}
