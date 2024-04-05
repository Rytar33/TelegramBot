namespace Domain.Entities.ValueObjects;

/// <summary>
/// ФИО
/// </summary>
public class FullName : BaseValueObject
{
    public FullName(string firstName, string lastName, string? middleName)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; init; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; init; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string? MiddleName { get; init; }

    public string GetFullName()
        => MiddleName != null
            ? $"{LastName} {FirstName} {MiddleName}"
            : $"{LastName} {FirstName}";
}