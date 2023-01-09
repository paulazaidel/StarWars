using StarWars.Domain.Entities;

namespace StarWars.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : EntityBase
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        Task<int> SaveChanges();
    }
}
