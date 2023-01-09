namespace StarWars.Domain.Entities
{
    public class Climate : EntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }
    }
}
