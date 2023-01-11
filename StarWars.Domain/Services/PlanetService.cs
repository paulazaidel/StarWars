using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;

namespace StarWars.Domain.Services
{
    public class PlanetService : IPlanetService
    {
        private readonly IPlanetRepository _repository;
        public PlanetService(IPlanetRepository repository)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task<Planet?> FindByName(string name)
        {
            Logs.INFO($"[PlanetService] Getting planet by name {name}.");

            var planet = await _repository.FindByName(name);

            if (planet == null)
                Logs.WARNING($"[PlanetService] Planet {name} not found.");

            return planet;
        }

        public async Task<Planet?> Get(int id)
        {
            var planet = await _repository.GetById(id);

            if (planet == null)
                Logs.WARNING($"[PlanetService] Planet id {id} not found.");

            return planet;
        }

        public async Task<IEnumerable<Planet>> GetAll()
        {
            var planets = await _repository.GetAll();

            Logs.INFO($"[PlanetService] Getted {planets.Count} planets.");

            return planets;
        }

        public async Task Remove(int id)
        {
            var planet = await _repository.GetById(id);

            if (planet == null) 
            {
                Logs.WARNING($"[PlanetService] Planet id {id} not found to remove.");
                return;
            }


            planet.RemovedAt = DateTime.UtcNow;

            await _repository.Update(planet);
        }
    }
}
