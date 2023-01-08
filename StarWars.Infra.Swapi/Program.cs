using StarWars.Infra.Swapi.Helpers;
using StarWars.Infra.Swapi.Models;
using StarWars.Infra.Swapi.UseCases;

Console.WriteLine("[SWAPI] Start...");

Console.WriteLine("[SWAPI] Getting data from swapi.dev");
var filmsData = FilmService.GetAll();
var planetsData = PlanetService.GetAll();


var planets = new List<PlanetModel>();
var terrains = new List<TerrainModel>();
var climates = new List<ClimateModel>();

var planetClimates = new List<PlanetClimateModel>();
var planetTerrains = new List<PlanetTerrainModel>();

var films = new List<FilmModel>();
var filmPlanets = new List<FilmPlanetModel>();

Console.WriteLine("[SWAPI] Generating models...");
foreach (var planetData in planetsData)
{
    planets.Add(new PlanetModel(planetData.Name));

    foreach (var climate in planetData.Climates)
    {
        var climateAlreadyExist = climates.Any(item => item.Name == climate);

        if (!climateAlreadyExist)
            climates.Add(new ClimateModel(climate));

        planetClimates.Add(new PlanetClimateModel(planetData.Name, climate));
    }

    foreach (var terrain in planetData.Terrains)
    {
        bool terrainAlreadyExist = terrains.Any(item => item.Name == terrain);

        if (!terrainAlreadyExist)
            terrains.Add(new TerrainModel(terrain));

        planetTerrains.Add(new PlanetTerrainModel(planetData.Name, terrain));
    }
}

foreach (var filmData in filmsData)
{
    films.Add(new FilmModel(filmData.Title, filmData.Director, filmData.ReleaseDate));   

    foreach (var item in filmData.PlanetsUrl) {
        var planet = planetsData.First(value => value.Url == item);
        filmPlanets.Add(new FilmPlanetModel(planet.Name, filmData.Title));
    }
}

Console.WriteLine($"[SWAPI] Planets Total: {planets.Count}");
Console.WriteLine($"[SWAPI] Terrains Total: {terrains.Count}");
Console.WriteLine($"[SWAPI] Climates Total: {climates.Count}");
Console.WriteLine($"[SWAPI] Films Total: {filmsData.Count}");


Console.WriteLine($"[SWAPI] Generating JSON files...");

JsonHelper.SaveJsonFile<PlanetModel>(planets, "planets.json");
JsonHelper.SaveJsonFile<TerrainModel>(terrains, "terrains.json");
JsonHelper.SaveJsonFile<ClimateModel>(climates, "climates.json");
JsonHelper.SaveJsonFile<PlanetClimateModel>(planetClimates, "planetClimates.json");
JsonHelper.SaveJsonFile<PlanetTerrainModel>(planetTerrains, "planetTerrains.json");
JsonHelper.SaveJsonFile<FilmModel>(films, "films.json");
JsonHelper.SaveJsonFile<FilmPlanetModel>(filmPlanets, "filmPlanets.json");

Console.WriteLine($"[SWAPI] Files generated!");
Console.WriteLine("END");


