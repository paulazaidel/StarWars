using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StarWars.Application.API.Dtos;
using StarWars.Domain.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace StarWars.Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanetService _service;
        public readonly IMapper _mapper;

        public PlanetController(IMapper mapper, IPlanetService repository)
        {
            _mapper = mapper;
            _service = repository;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Gets all planets",
            Description = "Returns a list of planets with films, climates and terrains."
        )]
        [SwaggerResponse(200, "Success", typeof(List<PlanetDto>))]
        public async Task<IActionResult> Get()
        {
            var planets = await _service.GetAll();
            var planetsDto = _mapper.Map<IEnumerable<PlanetDto>>(planets);

            return Ok(planetsDto);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Gets a planet by the id",
            Description = "Returns a planet with films, climates and terrains."
        )]
        [SwaggerResponse(200, "Success", typeof(PlanetDto))]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> Get(int id)
        {
            var planet = await _service.Get(id);

            if (planet == null)
                return NotFound();

            var planetDto = _mapper.Map<PlanetDto>(planet);
            return Ok(planetDto);
        }

        [HttpGet("search/{name}")]
        [SwaggerOperation(
            Summary = "Gets a planet by the name",
            Description = "Returns a planet with films, climates and terrains by the name. For this version, the name must be equals (upper and lower case)."
        )]
        [SwaggerResponse(200, "Success", typeof(PlanetDto))]
        [SwaggerResponse(404, "Not Found")]
        public async Task<IActionResult> Get(string name)
        {
            var planet = await _service.FindByName(name);

            if (planet == null)
                return NotFound();

            var planetDto = _mapper.Map<PlanetDto>(planet);
            return Ok(planetDto);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete a planet by the id",
            Description = "Warning: The planet deleted can be accessed later."
        )]
        [SwaggerResponse(200, "Success")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Remove(id);

            return Ok();
        }
    }
}
