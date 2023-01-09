using StarWars.Domain.Entities;
using System.Linq.Expressions;

namespace StarWars.Domain.Interfaces
{
    public interface IPlanetRepository : IRepository<Planet>
    {
        Task<IEnumerable<Planet>> Search(Expression<Func<Planet, bool>> predicate);

        Task Remove(Guid id);
    }
}
