namespace StarWars.Infra.Swapi.Models
{
    public class ClimateModel
    {
        public ClimateModel(string name) 
        { 
            Name = name;
        }

        public string Name { get; set; }
    }
}
