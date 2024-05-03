namespace Domain.Entities;

public class CustomField<TType> : BaseEntity
{
    public string Name { get; init; }

    public TType Value { get; init; }
}
