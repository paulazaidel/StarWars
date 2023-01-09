namespace StarWars.Domain.Entities
{
    public class Terrain : EntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }
    }
}
