using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AirlineReservationsSystem.Models
{
    public class AirplaneUpdateViewModel
    {
        public Airplane Airplane { get; set; }
        public List<SeatupdateModel> Seats { get; set; }
    }

    public class SeatupdateModel
    {
        public int SeatId { get; set; }
        //public int AirplaneId { get; set; }
        public int TotalNumber { get; set; }
        public SeatType Class { get; set; }

    }

}
