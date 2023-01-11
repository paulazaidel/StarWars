using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StarWars.Domain.Entities;

namespace StarWars.Infra.Data.Mappings
{
    public class PlanetMapping : IEntityTypeConfiguration<Planet>
    {
        public void Configure(EntityTypeBuilder<Planet> builder)
        {
            builder.HasKey(value => value.Id);

            builder.Property(value => value.Name)
                .IsRequired();

            builder.HasIndex(value => value.Name)
                .IsUnique();

            builder.HasMany(value => value.Climates)
                .WithMany(value => value.Planets)
                .UsingEntity(value => value.ToTable("PlanetClimates"));

            builder.HasMany(value => value.Terrains)
                .WithMany(value => value.Planets)
                .UsingEntity(value => value.ToTable("PlanetTerrains"));

            builder.HasMany(value => value.Films)
                .WithMany(value => value.Planets)
                .UsingEntity(value => value.ToTable("PlanetFilms"));

            builder.ToTable("Planets");
        }
    }
}
