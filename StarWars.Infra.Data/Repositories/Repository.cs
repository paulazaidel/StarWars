using Microsoft.EntityFrameworkCore;
using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using StarWars.Infra.Data.Context;

namespace StarWars.Infra.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {
        protected readonly StarWarsContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(StarWarsContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
