using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class User:IdentityUser
    {
        [Required]
        [MaxLength(100)]
        [StringLength(100)]
        public string? FullName { get; set; }

        [MaxLength(14)]
        [StringLength(14)]
        public override string? PhoneNumber { get; set; }
    }
}
