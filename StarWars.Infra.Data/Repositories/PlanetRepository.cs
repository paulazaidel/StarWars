using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using StarWars.Infra.Data.Context;
using System.Linq.Expressions;

namespace StarWars.Infra.Data.Repositories
{
    public class PlanetRepository : Repository<Planet>, IPlanetRepository
    {
        public PlanetRepository(StarWarsContext context) : base(context) { }

        public Task<IEnumerable<Planet>> Search(Expression<Func<Planet, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
