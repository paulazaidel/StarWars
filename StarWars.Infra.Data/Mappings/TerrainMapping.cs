using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StarWars.Domain.Entities;

namespace StarWars.Infra.Data.Mappings
{
    public class TerrainMapping : IEntityTypeConfiguration<Terrain>
    {
        public void Configure(EntityTypeBuilder<Terrain> builder)
        {
            builder.HasKey(value => value.Id);

            builder.Property(value => value.Name)
                .IsRequired();

            builder.HasIndex(value => value.Name)
                .IsUnique();

            builder.HasMany(value => value.Planets)
                .WithMany(value => value.Terrains)
                .UsingEntity(value => value.ToTable("PlanetTerrains"));

            builder.ToTable("Terrains");
        }
    }
}
