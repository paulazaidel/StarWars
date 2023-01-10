using StarWars.Domain.Entities;
using System.Linq.Expressions;

namespace StarWars.Domain.Interfaces
{
    public interface IPlanetRepository : IRepository<Planet>
    {
        Task<Planet?> FindByame(string name);
        Task Update(Planet planet);
    }
}
