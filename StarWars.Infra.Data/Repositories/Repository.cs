using Microsoft.EntityFrameworkCore;
using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;
using StarWars.Infra.Data.Context;

namespace StarWars.Infra.Data.Repositories
{
    public abstract class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : EntityBase, new()
    {
        protected readonly StarWarsContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(StarWarsContext context)
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

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity?> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
