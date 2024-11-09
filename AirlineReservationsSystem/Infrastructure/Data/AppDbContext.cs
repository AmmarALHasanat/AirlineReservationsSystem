using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AirlineReservationsSystem.Domain.Entities;

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

            // إعداد العلاقات بين الكائنات
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

            // تعريف العلاقات بين الكائنات الأخرى
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

            // العلاقة بين Flight و Seat عبر FlightSeat
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

            // العلاقة بين Seat و Airplane
            modelBuilder.Entity<Seat>()
                .HasOne(s => s.Airplane)
                .WithMany(a => a.Seats)
                .HasForeignKey(s => s.AirplaneId)
                .OnDelete(DeleteBehavior.Restrict);

            // إضافة فهرس فريد للـ PhoneNumber في الـ User
            modelBuilder.Entity<User>()
                .HasIndex(u => u.PhoneNumber)
                .IsUnique(true);
        }

        public static class DbInitializer
        {
            public static async Task Initialize(IServiceProvider serviceProvider)
            {
                var context = serviceProvider.GetRequiredService<AppDbContext>();

                // تأكد إذا كانت الجداول تحتوي على بيانات بالفعل (لا تضيف بيانات جديدة إذا كانت موجودة)
                if (context.Airplanes.Any())
                {
                    return; // البيانات موجودة مسبقًا
                }

                // إضافة طائرات افتراضية
                context.Airplanes.AddRange(
                    new Airplane { Model = "Boeing 747", Capacity = 400 },
                    new Airplane { Model = "Airbus A320", Capacity = 180 },
                    new Airplane { Model = "Cessna 172", Capacity = 4 }
                );

                // حفظ البيانات في قاعدة البيانات
                await context.SaveChangesAsync();
            }
        }


    }
}
