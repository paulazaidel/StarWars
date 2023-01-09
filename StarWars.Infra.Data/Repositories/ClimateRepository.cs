using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using StarWars.Infra.Data.Context;

namespace StarWars.Infra.Data.Repositories
{
    public class ClimateRepository : Repository<Climate>, IClimateRepository
    {
        public ClimateRepository(StarWarsContext context) : base(context) { }
    }
}
