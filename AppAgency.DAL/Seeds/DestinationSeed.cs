using AppAgency.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAgency.DAL.Seeds
{
    public class DestinationSeed : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.HasData(
                new Destination() { Id=1,Country="Belgique",City="Bruxelles", Description= "Washington d'Europe" },
                new Destination() { Id=2,Country="France",City="Paris", Description="Ville lumière"},
                new Destination() { Id=3,Country="Espagne",City="Barcelone", Description="Ville de Gaudi"},
                new Destination() { Id=4,Country="Royaume-Uni",City="Londres", Description= "Ville-monde" }
                );
        }
    }
}
