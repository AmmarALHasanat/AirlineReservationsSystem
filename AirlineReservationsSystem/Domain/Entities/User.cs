using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "الاسم الكامل مطلوب.")]
        [MaxLength(100, ErrorMessage = "الاسم الكامل يجب ألا يتجاوز 100 حرف.")]
        public string? FullName { get; set; } // الاسم الكامل للمستخدم

        
        [MaxLength(14, ErrorMessage = "رقم الهاتف يجب ألا يتجاوز 14 حرف.")]
        public override string? PhoneNumber { get; set; } // رقم الهاتف للمستخدم

        // قائمة الحجوزات المرتبطة بالمستخدم
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();



    }
}
