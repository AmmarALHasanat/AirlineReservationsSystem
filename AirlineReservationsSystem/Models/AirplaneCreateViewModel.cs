using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AirlineReservationsSystem.Models
{
    public class AirplaneCreateViewModel
    {
        public Airplane airplane { get; set; } = new Airplane();
        public List<SeatInputModel> Seats { get; set; } = new List<SeatInputModel>();
    }

    public class SeatInputModel
    {
        public SeatType Class { get; set; }
        public int TotalNumber { get; set; }
    }

}
