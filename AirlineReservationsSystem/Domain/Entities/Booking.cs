using AirlineReservationsSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace AirlineReservationsSystem.Domain.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public virtual ICollection<FlightSeat> FlightSeats { get; set; } = new List<FlightSeat>();
        public int FlightId {  get; set; }//
        public Flight Flight { get; set; }
        public DateTime BookingDate { get; set; }
        public BookingStatus Status { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }


        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

        public decimal TotalPrice()
        {
            return Tickets.Sum(ticket => ticket.Price);
        }

    }

}
