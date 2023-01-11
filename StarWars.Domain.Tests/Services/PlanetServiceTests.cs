using Moq;
using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using StarWars.Domain.Services;

namespace StarWars.Domain.Tests.Services
{
    public class PlanetServiceTests
    {
        [Fact]
        public async void GetById_Success()
        {
            // Arrange
            var id = 1;
            var planet = (new Planet() { Id = id });
            var planetRepository = new Mock<IPlanetRepository>();
            planetRepository.Setup(props => props.GetById(id))
               .Returns(Task.FromResult(planet));

            var planetService = new PlanetService(planetRepository.Object);

            // Act
            var result = await planetService.Get(id);

            // Assert
            Assert.NotNull(planet);
            planetRepository.Verify(r => r.GetById(id), Times.Once);
        }

        [Fact]
        public async void GetAll_Success()
        {
            // Arrange
            var planets = new List<Planet>();
            planets.Add(new Planet() { Id = 1 });
            planets.Add(new Planet() { Id = 2 });

            var planetRepository = new Mock<IPlanetRepository>();
            planetRepository.Setup(props => props.GetAll())
               .Returns(Task.FromResult(planets));

            var planetService = new PlanetService(planetRepository.Object);

            // Act
            var result = await planetService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.ToList().Count, planets.Count);
            planetRepository.Verify(r => r.GetAll(), Times.Once);
        }

        [Fact]
        public async void FindByName_Success()
        {
            // Arrange
            var id = 1;
            var name = "Test";
            var planet = (new Planet() { Id = id, Name = name });

            var planetRepository = new Mock<IPlanetRepository>();
            planetRepository.Setup(props => props.FindByName(name))
               .Returns(Task.FromResult(planet));

            var planetService = new PlanetService(planetRepository.Object);

            // Act
            var result = await planetService.FindByName(name);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(planet.Name, name);
            planetRepository.Verify(r => r.FindByName(name), Times.Once);
        }

        [Fact]
        public async void Remove_Success()
        {
            // Arrange
            var id = 1;
            var name = "Test";
            var planet = (new Planet() { Id = id, Name = name });

            var planetRepository = new Mock<IPlanetRepository>();
            planetRepository.Setup(props => props.GetById(id))
               .Returns(Task.FromResult(planet));
            planetRepository.Setup(props => props.Update(planet));

            var planetService = new PlanetService(planetRepository.Object);

            // Act
            await planetService.Remove(id);

            // Assert
            planetRepository.Verify(r => r.GetById(id), Times.Once);
            planetRepository.Verify(r => r.Update(planet), Times.Once);
        }
    }
}
