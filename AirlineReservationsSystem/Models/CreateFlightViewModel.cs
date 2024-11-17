using AirlineReservationsSystem.Domain.Entities;

namespace AirlineReservationsSystem.Models
{
    public class CreateFlightViewModel
    {
        public List<Airplane> Airplanes { get; set; } = new List<Airplane>();
        public List<TravelRoute> Routes { get; set; } = new List<TravelRoute>();
        public string FlightNumber { get; set; }
        public int AirplaneId { get; set; }
        public int TravelRouteId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal EconomyClassPrice { get; set; }
        public decimal BusinessClassPrice { get; set; }
        public decimal FirstClassPrice { get; set; }
    }

}
