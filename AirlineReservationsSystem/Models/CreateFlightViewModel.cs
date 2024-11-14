using AirlineReservationsSystem.Domain.Entities;

namespace AirlineReservationsSystem.Models
{
    public class CreateFlightViewModel
    {
        public List<Airplane> Airplanes { get; set; }
        public List<TravelRoute> Routes { get; set; }
        public string FlightNumber { get; set; }
        public int AirplaneId { get; set; }
        public int TravelRouteId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }

}
