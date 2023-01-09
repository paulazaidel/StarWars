using Microsoft.EntityFrameworkCore;
using StarWars.Domain.Entities;

namespace StarWars.Infra.Data.Context
{
    public class StarWarsContext : DbContext
    {
        public StarWarsContext() { }
        public StarWarsContext(DbContextOptions<StarWarsContext> options) : base(options) { }

        public DbSet<Climate> Climates { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Terrain> Terrains { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure mvarchar to varchar
            foreach (var property in modelBuilder
               .Model
               .GetEntityTypes()
               .SelectMany(
                  e => e.GetProperties()
                     .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            // Configure Mappings
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StarWarsContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
