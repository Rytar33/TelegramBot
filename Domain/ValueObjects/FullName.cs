namespace Domain.ValueObjects;
/// <summary>
/// Фамилия, имя, отчество
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
    /// <summary>
    /// Метод, который возвращает ФИО
    /// </summary>
    /// <returns>Возвращает ФИО или ФИ, в зависимости от того, есть ли отчество или нету</returns>
    public string GetFullName() 
        => MiddleName != null 
            ? $"{LastName} {FirstName} {MiddleName}" 
            : $"{LastName} {FirstName}";
}