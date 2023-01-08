namespace StarWars.Infra.Swapi.DataModel
{
    public class FilmDataModel
    {
        public FilmDataModel(string title, string director, string releaseDate, IEnumerable<string> planetsUrl)
        {
            Title = title;
            Director = director;
            ReleaseDate = releaseDate;
            PlanetsUrl = planetsUrl;
        }

        public string Title { get; set; }
        public string Director { get; set; }
        public string ReleaseDate { get; set; }
        public IEnumerable<string> PlanetsUrl { get; set; }
    }
}
