using AppAgency.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAgency.DAL.Seeds
{
    public class BookingSeed : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasData(
                new { Id=1,ClientName="Bill Cypher", BookingDate=new DateTime(2026,05,10)},
                new { Id=2,ClientName="Dipper Pines", BookingDate=new DateTime(2026,05,11)},
                new { Id=3,ClientName="Mabel Pines", BookingDate=new DateTime(2026,01,20)}
            );
        }
    }
}
