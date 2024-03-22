namespace Domain.Entities;
/// <summary>
/// Базовый класс для всех сущностей
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public Guid Id { get; }

    public override bool Equals(object? obj)
        => obj != null 
               && obj is BaseEntity entity
               && Id == entity.Id;

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}