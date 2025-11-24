using AppAgency.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAgency.DAL.Configuration
{
    public class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");

            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.BookingDate).IsRequired().HasColumnType("date");
            builder.Property(b => b.ClientName).IsRequired().HasMaxLength(70);

            //constrains
            builder.HasKey(b => b.Id).HasName("PK_Booking");
            builder.ToTable(b => b.HasCheckConstraint("CK_Bookind_Date","[BookingDate] >= GetDate()"));

            // relations
            // booking<>destination
            builder.HasOne(b => b.Destination)
                .WithMany(d => d.Bookings)
                .HasForeignKey("DestinationId")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            // booking<>activity
            builder.HasMany(b => b.Activities)
                .WithMany(a => a.Bookings)
                .UsingEntity(
                "ActivityBooked",
                     left => left.HasOne(typeof(Activity))
                             .WithMany()
                             .HasForeignKey("ActivityId")
                             .HasPrincipalKey(nameof(Activity.Id)),
                     right => right.HasOne(typeof(Booking))
                             .WithMany()
                             .HasForeignKey("BookId")
                             .HasPrincipalKey(nameof(Booking.Id)), 
                     join => join.HasKey("BookId","ActivityId"));

          
           
        }
    }

}
