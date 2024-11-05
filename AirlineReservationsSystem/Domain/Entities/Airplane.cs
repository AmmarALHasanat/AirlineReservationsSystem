using System.ComponentModel.DataAnnotations;

namespace AirlineReservationsSystem.Domain.Entities
{
    public class Airplane
    {
        public int AirplaneId { get; set; } // المعرف الفريد لكل طائرة

        [Required]
        [MaxLength(100)]
        public string Model { get; set; } // نموذج أو نوع الطائرة

        [Required]
        public int Capacity { get; set; } // السعة الإجمالية للجلوس
    }
}
