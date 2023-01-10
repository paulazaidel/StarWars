using Microsoft.EntityFrameworkCore;
using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using StarWars.Infra.Data.Context;

namespace StarWars.Infra.Data.Repositories
{
    public class PlanetRepository : Repository<Planet>, IPlanetRepository
    {
        public PlanetRepository(StarWarsContext context) : base(context) { }

        public override async Task<List<Planet>> GetAll()
        {
            return await Context.Planets
                .AsNoTracking()
                .Include(p => p.Terrains)
                .Include(p => p.Films)
                .Include(p => p.Climates)
                .ToListAsync();
        }

        public override async Task<Planet> GetById(int id)
        {
            return await Context.Planets
                .Include(p => p.Terrains)
                .Include(p => p.Films)
                .Include(p => p.Climates)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Update(Planet planet)
        {
            Context.Planets.Update(planet);
            await SaveChanges();
        }

        public async Task<Planet?> FindByame(string name)
        {
            return await Context.Planets.Where(value => value.Name == name)
                .Include(p => p.Terrains)
                .Include(p => p.Films)
                .Include(p => p.Climates)
                .FirstOrDefaultAsync();

        }
    }
}
