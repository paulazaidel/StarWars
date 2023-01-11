using Microsoft.EntityFrameworkCore;
using StarWars.Domain.Entities;
using StarWars.Infra.Data.Context;
using StarWars.Infra.Data.Repositories;

namespace StarWars.Infra.Data.Tests.Repositories
{
    public class PlanetRepositoryTests
    {
        private readonly PlanetRepository _planetRepository;
        private readonly StarWarsContext _context;
        public PlanetRepositoryTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StarWarsContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            _context = new StarWarsContext(optionsBuilder.Options);
            _planetRepository = new PlanetRepository(_context);

            var planet = new Planet() { Name = "Test" };
            var planetRemoved = new Planet() { Name = "Test_Removed", RemovedAt = DateTime.UtcNow };


            _context.Planets.Add(planet);
            _context.Planets.Add(planetRemoved);
            _context.SaveChanges();
        }

        [Fact]
        public async void Add_Success()
        {
            // Arrange
            var name = "TestAdd";

            // Act
            await _planetRepository.Add(new Planet() { Name = name });

            // Assert
            var expected = _context.Planets.FirstOrDefault(x => x.Name == name);
            Assert.NotNull(expected);
        }

        [Fact]
        public async void FindByName_Success()
        {
            // Arrange
            var name = "Test";

            // Act
            var result = await _planetRepository.FindByName(name);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
        }

        [Fact]
        public async void FindByName_Sould_Not_Return_Removed()
        {
            // Arrange
            var name = "Test_Removed";

            // Act
            var result = await _planetRepository.FindByName(name);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async void GetAll_Success()
        {
            // Arrange
            var name = "Test";

            // Act
            var result = await _planetRepository.GetAll();

            // Assert
            var expected = _context.Planets.Where(prop => prop.RemovedAt == null).ToList();
            Assert.NotNull(result);
            Assert.Equal(expected.Count, result.Count); ;
        }

        [Fact]
        public async void GetById_Success()
        {
            // Arrange
            var id = 1;

            // Act
            var result = await _planetRepository.GetById(id);

            // Assert
            Assert.NotNull(result);
        }
    }
}
