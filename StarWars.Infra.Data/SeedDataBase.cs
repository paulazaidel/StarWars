using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StarWars.Domain.Entities;
using StarWars.Infra.Data.Context;

namespace StarWars.Infra.Data
{
    public class SeedDataBase
    {
        private readonly StarWarsContext _context;

        private readonly string? _path;

        public SeedDataBase(StarWarsContext context)
        {
            _context = context;
            _path = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;

            if (_path == null)
                throw new ArgumentNullException(_path);
        }

        public void SeedClimates()
        {
            var climateData = File.ReadAllText($"{_path}\\climates.json");
            var climates = JsonConvert.DeserializeObject<List<Climate>>(climateData);

            if (climates == null) return; 

            foreach (var climate in climates)
            {
                _context.Climates.Add(climate);
            }

            _context.SaveChanges();
        }

        public void SeedFilms() 
        {
            var filmData = File.ReadAllText($"{_path}\\films.json");
            var films = JsonConvert.DeserializeObject<List<Film>>(filmData);

            if (films == null) return;

            foreach (var film in films)
            {
                _context.Films.Add(film);
            }

            _context.SaveChanges();
        }
        public void SeedTerrains() 
        {
            var terrainData = File.ReadAllText($"{_path}\\terrains.json");
            var terrains = JsonConvert.DeserializeObject<List<Terrain>>(terrainData);

            if (terrains == null) return;

            foreach (var terrain in terrains)
            {
                _context.Terrains.Add(terrain);
            }

            _context.SaveChanges();
        }

        public void SeedPlanets()
        {
            var planetData = File.ReadAllText($"{_path}\\planets.json");
            var planets = JsonConvert.DeserializeObject<List<Planet>>(planetData);

            var planetTerrains = _GetPlanetTerrains();
            var planetFilms = _GetPlanetFilms();
            var planetClimates = _GetPlanetClimates();

            if (planets == null) return;

            foreach (var planet in planets)
            {
                var terrains = planetTerrains.GetValueOrDefault(planet.Name);
                var films = planetFilms.GetValueOrDefault(planet.Name);
                var climates = planetClimates.GetValueOrDefault(planet.Name);

                planet.Terrains = new List<Terrain>();
                planet.Films = new List<Film>();
                planet.Climates = new List<Climate>();

                terrains?.ForEach(name => 
                {
                    var terrain = _context.Terrains.FirstOrDefault(s => s.Name == name);
                    planet.Terrains.Add(terrain);
                });


                films?.ForEach(title =>
                {
                    var film = _context.Films.FirstOrDefault(s => s.Title == title);
                    planet.Films.Add(film);
                });


                climates?.ForEach(name =>
                {
                    var climate = _context.Climates.FirstOrDefault(s => s.Name == name);
                    planet.Climates.Add(climate);
                });

                _context.Planets.Add(planet);
            }

            _context.SaveChanges();
        }

        private Dictionary<string, List<string>> _GetPlanetTerrains()
        {
            var terrainData = File.ReadAllText($"{_path}\\planetTerrains.json");
            var jToken = JToken.Parse(terrainData);
            var terrains = new Dictionary<string, List<string>>();

            foreach (var value in jToken)
            {
                var planet = value["Planet"]?.ToString();
                var terrain = value["Terrain"]?.ToString();

                if (planet == null || terrain == null)
                    continue;

                if (terrains.ContainsKey(planet))
                {
                    terrains[planet].Add(terrain);
                }
                else
                {
                    terrains.Add(planet, new List<string>() { terrain });
                }
            }

            return terrains;
        }

        private Dictionary<string, List<string>> _GetPlanetFilms()
        {
            var filmData = File.ReadAllText($"{_path}\\filmPlanets.json");
            var jToken = JToken.Parse(filmData);
            var films = new Dictionary<string, List<string>>();

            foreach (var value in jToken)
            {

                var planet = value["Planet"]?.ToString();
                var film = value["Film"]?.ToString();

                if (planet == null || film == null)
                    continue;

                if (films.ContainsKey(planet))
                {
                    films[planet].Add(film);
                }
                else
                {
                    films.Add(planet, new List<string>() { film });
                }
            }

            return films;
        }

        private Dictionary<string, List<string>> _GetPlanetClimates()
        {
            var climateData = File.ReadAllText($"{_path}\\planetClimates.json");
            var jToken = JToken.Parse(climateData);
            var climates = new Dictionary<string, List<string>>();

            foreach (var value in jToken)
            {
                var planet = value["Planet"]?.ToString();
                var climate = value["Climate"]?.ToString();

                if (planet == null || climate == null)
                    continue;

                if (climates.ContainsKey(planet))
                {
                    climates[planet].Add(climate);
                }
                else
                {
                    climates.Add(planet, new List<string>() { climate });
                }
            }

            return climates;
        }
    }
}
