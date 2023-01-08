namespace StarWars.Infra.Swapi.Models
{
    public class PlanetTerrainModel
    {
        public PlanetTerrainModel(string planet, string terrain)
        {
            Planet = planet;
            Terrain = terrain;
        }

        public string Planet { get; set; }
        public string Terrain { get; set; }
    }
}

