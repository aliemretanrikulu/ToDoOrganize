using Core.Entities;

namespace Core.Repositories;

public interface IRepository<TEntity, TId> 
    where TEntity : Entity<TId>, new()
{
    List<TEntity> GetAll();
    TEntity GetById(TId id);
    TEntity Update(TEntity entity);
    TEntity Add(TEntity entity);
    TEntity Remove(TEntity entity);
}

