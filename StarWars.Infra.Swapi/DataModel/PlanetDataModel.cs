namespace StarWars.Infra.Swapi.DataModel
{
    public class PlanetDataModel
    {
        public PlanetDataModel(string name, string climate, string terrain, string url)
        {
            Name = name;
            Url = url;
            _climates = climate;
            _terrains = terrain;
        }

        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        private string _climates;

        public IEnumerable<string> Climates
        {
            get
            {
                return _climates.Split(", ");
            }
        }

        private string _terrains;

        public IEnumerable<string> Terrains
        {
            get
            {
                return _terrains.Split(", ");
            }
        }
    }
}
