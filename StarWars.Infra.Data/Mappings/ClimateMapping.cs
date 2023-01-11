using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.Domain.Entities;

namespace StarWars.Infra.Data.Mappings
{
    public  class ClimateMapping : IEntityTypeConfiguration<Climate>
    {
        public void Configure(EntityTypeBuilder<Climate> builder)
        {
            builder.HasKey(value => value.Id);

            builder.Property(value => value.Name)
                .IsRequired();

            builder.HasIndex(value => value.Name)
                .IsUnique();

            builder.HasMany(value => value.Planets)
                .WithMany(value => value.Climates)
                .UsingEntity(value => value.ToTable("PlanetClimates"));

            builder.ToTable("Climates");
        }
    }
}
