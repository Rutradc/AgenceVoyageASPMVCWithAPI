using AppAgency.DAL.Configuration;
using AppAgency.DAL.Seeds;
using AppAgency.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AppAgency.DAL
{
    public class AgenceDbContext : DbContext
    {
        public DbSet<Destination> Destinations {  get; set; }
        public DbSet<Activity> Activities {  get; set; }
        public DbSet<Booking> Bookings {  get; set; }
        public AgenceDbContext(DbContextOptions<AgenceDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DestinationConfig());
            modelBuilder.ApplyConfiguration(new DestinationSeed());

            modelBuilder.ApplyConfiguration(new ActivityConfig());
            modelBuilder.ApplyConfiguration(new ActivitySeed());

            modelBuilder.ApplyConfiguration(new BookingConfig());
            modelBuilder.ApplyConfiguration(new BookingSeed());


            modelBuilder.Entity("ActivityBooked")
                .HasData(
                    new { BookId = 1, ActivityId = 1 },
                    new { BookId = 1, ActivityId = 2 },
                    new { BookId = 2, ActivityId = 3 }
                 );
        }

    };
        
}
