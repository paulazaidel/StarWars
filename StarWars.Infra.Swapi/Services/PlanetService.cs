using StarWars.Infra.Swapi.DataModel;
using StarWarsApiCSharp;

namespace StarWars.Infra.Swapi.UseCases
{
    public static class PlanetService
    {
        public static List<PlanetDataModel> GetAll()
        {
            var plnetsRepository = new Repository<Planet>();
            var planetsData = plnetsRepository.GetEntities(size: int.MaxValue);
            var planets = new List<PlanetDataModel>();

            foreach (var planet in planetsData)
            {
                planets.Add(new PlanetDataModel(planet.Name, planet.Climate, planet.Terrain, planet.Url));
            }

            return planets;
        }
    }
}
