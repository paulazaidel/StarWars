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

        public async Task<Planet?> FindByame(string name)
        {
            return await _repository.FindByame(name);
        }

        public async Task<Planet> Get(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Planet>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task Remove(int id)
        {
            var planet = await _repository.GetById(id);

            if (planet == null)
                return;

            planet.RemovedAt = DateTime.UtcNow;

            _repository.Update(planet);
        }
    }
}
