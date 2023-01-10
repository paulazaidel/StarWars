using AutoMapper;
using StarWars.Application.API.Dtos;
using StarWars.Domain.Entities;

namespace StarWars.Application.API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Climate, ClimateDto>();
            CreateMap<Terrain, TerrainDto>();
            CreateMap<Film, FilmDto>();
            CreateMap<Planet, PlanetDto>();
        }
    }
}
