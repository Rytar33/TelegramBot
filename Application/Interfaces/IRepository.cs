using Domain.Entities;

namespace Application.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> GetById(Guid id);

    Task<IEnumerable<TEntity>> GetAll();

    Task<TEntity> Create(TEntity entity);

    Task<TEntity> Update(TEntity entity);

    Task<bool> Remove(Guid id);
}