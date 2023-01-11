using StarWars.Infra.Swapi.DataModel;
using StarWarsApiCSharp;

namespace StarWars.Infra.Swapi.UseCases
{
    public static class FilmService
    {
        public static List<FilmDataModel> GetAll()
        {
            var filmsRepository = new Repository<Film>();
            var filmsData = filmsRepository.GetEntities(size: int.MaxValue);
            var films = new List<FilmDataModel>();

            foreach (var film in filmsData)
            {
                films.Add(new FilmDataModel(film.Title, film.Director, film.ReleaseDate, film.Planets));

            }

            return films;
        }
    }
}
