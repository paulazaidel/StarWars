namespace StarWars.Domain.Entities
{
    public class Planet : EntityBase
    {
        public string Name { get; set; }
        public DateTime? RemovedAt { get; set; }

        public virtual ICollection<Climate> Climates { get; set; }
        public virtual ICollection<Terrain> Terrains { get; set; }
        public virtual ICollection<Film> Films { get; set; }
    }
}
