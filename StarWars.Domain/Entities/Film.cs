namespace StarWars.Domain.Entities
{
    public class Film : EntityBase
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }

    }
}
