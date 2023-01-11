using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.Domain.Entities;

namespace StarWars.Infra.Data.Mappings
{
    public class FilmMapping : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasKey(value => value.Id);

            builder.Property(value => value.Title)
                .IsRequired();

            builder.HasIndex(value => value.Title)
                .IsUnique();

            builder.HasMany(value => value.Planets)
                .WithMany(value => value.Films)
                .UsingEntity(value => value.ToTable("PlanetFilms"));

            builder.ToTable("Films");
        }
    }
}
