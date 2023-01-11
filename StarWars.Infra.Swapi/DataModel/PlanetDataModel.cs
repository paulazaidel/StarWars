namespace StarWars.Infra.Swapi.DataModel
{
    public class PlanetDataModel
    {
        public PlanetDataModel(string name, string climate, string terrain, string url)
        {
            Name = name;
            Url = url;
            climates = climate;
            terrains = terrain;
        }

        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        private readonly string climates;

        public IEnumerable<string> Climates
        {
            get
            {
                return climates.Split(", ");
            }
        }

        private readonly string terrains;

        public IEnumerable<string> Terrains
        {
            get
            {
                return terrains.Split(", ");
            }
        }
    }
}
