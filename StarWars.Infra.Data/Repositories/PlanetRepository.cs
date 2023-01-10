using Microsoft.EntityFrameworkCore;
using StarWars.Domain;
using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using StarWars.Infra.Data.Context;
using System.Numerics;

namespace StarWars.Infra.Data.Repositories
{
    public class PlanetRepository : Repository<Planet>, IPlanetRepository
    {
        public PlanetRepository(StarWarsContext context) : base(context) { }

        public override async Task<List<Planet>> GetAll()
        {
            Logs.INFO("[PlanetRepository] Getting all planets.");

            return await Context.Planets.Where(prop => prop.RemovedAt == null)
                .AsNoTracking()
                .Include(p => p.Terrains)
                .Include(p => p.Films)
                .Include(p => p.Climates)
                .ToListAsync();
        }

        public override async Task<Planet?> GetById(int id)
        {
            Logs.INFO($"[PlanetRepository] Getting planet by id = {id}.");

            return await Context.Planets
                .Include(prop => prop.Terrains)
                .Include(prop => prop.Films)
                .Include(prop => prop.Climates)
                .FirstOrDefaultAsync(prop => prop.Id == id && prop.RemovedAt == null);
        }

        public async Task Update(Planet planet)
        {
            Logs.INFO($"[PlanetRepository] Updating planet by id = {planet.Id}.");

            Context.Planets.Update(planet);
            await SaveChanges();
        }

        public async Task<Planet?> FindByame(string name)
        {
            Logs.INFO($"[PlanetRepository] Getting planet by name = {name}");

            return await Context.Planets.Where(prop => prop.Name == name && prop.RemovedAt == null)
                .Include(prop => prop.Terrains)
                .Include(prop => prop.Films)
                .Include(prop => prop.Climates)
                .FirstOrDefaultAsync();

        }
    }
}
