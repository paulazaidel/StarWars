using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StarWars.Application.API.Dtos;
using StarWars.Domain.Services;

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
        public async Task<IActionResult> Get()
        {
            var planets = await _service.GetAll();
            var planetsDto = _mapper.Map<IEnumerable<PlanetDto>>(planets);

            return Ok(planetsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var planet = await _service.Get(id);

            if (planet == null)
                return NotFound();

            var planetDto = _mapper.Map<PlanetDto>(planet);
            return Ok(planetDto);
        }

        [HttpGet("search/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var planet = await _service.FindByame(name);

            if (planet == null)
                return NotFound();

            var planetDto = _mapper.Map<PlanetDto>(planet);
            return Ok(planetDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Remove(id);

            return Ok();
        }
    }
}
