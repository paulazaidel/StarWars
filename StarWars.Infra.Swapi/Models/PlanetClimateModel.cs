namespace StarWars.Infra.Swapi.Models
{
    public class PlanetClimateModel
    {
        public PlanetClimateModel(string planet, string climate) 
        {
            Planet = planet;
            Climate = climate;
        }

        public string Planet { get; set; }
        public string Climate { get; set; }
    }
}
