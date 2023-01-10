using Microsoft.EntityFrameworkCore;
using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using StarWars.Infra.Data.Context;
using System.Xml.Linq;

namespace StarWars.Infra.Data.Repositories
{
    public class PlanetRepository : Repository<Planet>, IPlanetRepository
    {
        public PlanetRepository(StarWarsContext context) : base(context) { }

        public override async Task<List<Planet>> GetAll()
        {
            return await Context.Planets.Where(prop => prop.RemovedAt == null)
                .AsNoTracking()
                .Include(p => p.Terrains)
                .Include(p => p.Films)
                .Include(p => p.Climates)
                .ToListAsync();
        }

        public override async Task<Planet> GetById(int id)
        {
            return await Context.Planets
                .Include(prop => prop.Terrains)
                .Include(prop => prop.Films)
                .Include(prop => prop.Climates)
                .FirstOrDefaultAsync(prop => prop.Id == id && prop.RemovedAt == null);
        }

        public async Task Update(Planet planet)
        {
            Context.Planets.Update(planet);
            await SaveChanges();
        }

        public async Task<Planet?> FindByame(string name)
        {
            return await Context.Planets.Where(prop => prop.Name == name && prop.RemovedAt == null)
                .Include(prop => prop.Terrains)
                .Include(prop => prop.Films)
                .Include(prop => prop.Climates)
                .FirstOrDefaultAsync();

        }
    }
}
