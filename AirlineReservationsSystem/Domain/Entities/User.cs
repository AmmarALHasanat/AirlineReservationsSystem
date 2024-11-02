using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class User:IdentityUser
    {
        [StringLength(100)]
        [MaxLength(100)]
        [Required]
        public string? FullName { get; set; }

        [StringLength(100)]
        [MaxLength(100)]
        [Required]
        public override string? PhoneNumber { get; set; }
    }
}
