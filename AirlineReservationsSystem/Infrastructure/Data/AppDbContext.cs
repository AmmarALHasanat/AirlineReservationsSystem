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

        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<TravelRoute> Routes { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<FlightSeat> FlightSeats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ضبط العلاقة بين المستخدم والحجوزات
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);

            // ضبط العلاقة بين الرحلة والحجوزات
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Flight)
                .WithMany(f => f.Bookings)
                .HasForeignKey(b => b.FlightId);

            // ضبط العلاقة بين المسؤول والمستخدم
            modelBuilder.Entity<Admin>()
                .HasOne<User>()
                .WithMany() // إزالة WithMany() إذا كان العلاقة One-to-One
                .HasForeignKey(a => a.AdminId);

            // ضبط العلاقة بين المقاعد والرحلات في FlightSeat
            modelBuilder.Entity<FlightSeat>()
                .HasOne(fs => fs.Flight)
                .WithMany(f => f.FlightSeats)
                .HasForeignKey(fs => fs.FlightId);

            modelBuilder.Entity<FlightSeat>()
                .HasOne(fs => fs.Seat)
                .WithMany(s => s.FlightSeats)
                .HasForeignKey(fs => fs.SeatId);
        }
    }
}
