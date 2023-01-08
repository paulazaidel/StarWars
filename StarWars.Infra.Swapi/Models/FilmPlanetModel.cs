namespace StarWars.Infra.Swapi.Models
{
    public class FilmPlanetModel
    {
        public FilmPlanetModel(string planet, string film) 
        {
            Planet = planet;
            Film = film;
        }

        public string Planet { get; set; }
        public string Film { get; set; }
    }
}
