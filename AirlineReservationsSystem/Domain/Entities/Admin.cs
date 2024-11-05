using System.ComponentModel.DataAnnotations;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class Admin
    {
        public String AdminId { get; set; } // المعرف الفريد للمدير (يرتبط بمعرف المستخدم)

        [Required]
        [MaxLength(100)]
        public string Role { get; set; } // الدور المحدد للمدير (مثل: مدير نظام، مدير رحلات)

        [Required]
        [MaxLength(255)]
        public string Email { get; set; } // عنوان البريد الإلكتروني للمدير

        [Required]
        [MaxLength(255)]
        public string Password { get; set; } // كلمة المرور للمدير

        public string UserId { get; set; } // معرف المستخدم المرتبط
        public User User { get; set; } // العلاقة مع كلاس User
    }
}
