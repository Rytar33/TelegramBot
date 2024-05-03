namespace Domain.Entities;

/// <summary>
/// Базовый класс для всех сущностей
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; protected set; }

    public override bool Equals(object? obj)
        => obj is not null
           && obj is BaseEntity entity
           && Id == entity.Id
           && GetHashCode() == entity.GetHashCode();
    
    public override int GetHashCode()
        => Id.GetHashCode();
}