namespace StarWars.Infra.Swapi.Models
{
    public class FilmModel
    {
        public FilmModel(string title, string director, string releaseDate)
        {
            Title = title.ToLower();
            Director = director;
            ReleaseDate = releaseDate;
        }

        public string Title { get; set; }
        public string Director { get; set; }
        public string ReleaseDate { get; set; }
    }
}
