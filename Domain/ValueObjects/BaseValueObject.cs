namespace Domain.ValueObjects;
/// <summary>
/// Базовый класс для наследуемых объектов к сущностям
/// </summary>
public abstract class BaseValueObject
{
    public override bool Equals(object? obj)
        => obj != null
            ;

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}