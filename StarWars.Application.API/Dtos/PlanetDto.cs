namespace StarWars.Application.API.Dtos
{
    public class PlanetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ClimateDto> Climates { get; set; }
        public virtual ICollection<TerrainDto> Terrains { get; set; }
        public virtual ICollection<FilmDto> Films { get; set; }
    }
}
