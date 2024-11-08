using AirlineReservationsSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservationsSystem.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightSeat> FlightSeats { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TravelRoute> Routes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //User Relations
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Booking Relations
            modelBuilder.Entity<Booking>()
                .HasMany(b => b.Tickets)
                .WithOne(t => t.Booking)
                .HasForeignKey(t => t.BookingId)
                .OnDelete(DeleteBehavior.Restrict);

            // Flight Relations
            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Tickets)
                .WithOne(t => t.Flight)
                .HasForeignKey(t => t.FlightId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Airplane)
                .WithMany(a => a.Flights)
                .HasForeignKey(f => f.AirplaneId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Route)
                .WithMany(tr => tr.Flights)
                .HasForeignKey(f => f.RouteId)
                .OnDelete(DeleteBehavior.Restrict);

            // M:N Flight and Seat name FlightSeat
            modelBuilder.Entity<Flight>()
                .HasMany(f => f.FlightSeats)
                .WithOne(fs => fs.Flight)
                .HasForeignKey(fs => fs.FlightId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Seat>()
                .HasMany(s => s.FlightSeats)
                .WithOne(fs => fs.Seat)
                .HasForeignKey(fs => fs.SeatId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FlightSeat>()
                    .HasKey(fs => fs.FlightSeatId);

            // Seat Relations  M:1 Seat : Airplane
            modelBuilder.Entity<Seat>()
                .HasOne(s => s.Airplane)
                .WithMany(a => a.Seats)
                .HasForeignKey(s => s.AirplaneId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasIndex( u => u.PhoneNumber)
                .IsUnique(true);
        }
    }
}
