namespace StarWars.Infra.Swapi.Models
{
    public class PlanetModel
    {
        public PlanetModel (string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
