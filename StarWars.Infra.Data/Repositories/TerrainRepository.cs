using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using StarWars.Infra.Data.Context;

namespace StarWars.Infra.Data.Repositories
{
    public class TerrainRepository : Repository<Terrain>, ITerrainRepository
    {
        public TerrainRepository(StarWarsContext context) : base(context) { }
    }
}
