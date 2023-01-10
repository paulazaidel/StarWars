using Microsoft.AspNetCore.Mvc;
using StarWars.Domain.Services;

namespace StarWars.Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanetService _service;

        public PlanetController(IPlanetService repository)
        {
            _service = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var planets = await _service.GetAll();

            return Ok(planets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var planet = await _service.Get(id);

            if (planet == null)
                return NotFound();

            return Ok(planet);
        }

        [HttpGet("search/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var planet = await _service.FindByame(name);

            if (planet == null)
                return NotFound();

            return Ok(planet);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Remove(id);

            return Ok();
        }
    }
}
