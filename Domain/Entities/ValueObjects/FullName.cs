using Domain.Validations;
using Domain.Validations.Validators;

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
        new FullNameValidator(nameof(FullName)).ValidateWithErrors(this);
    }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; private set; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; private set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string? MiddleName { get; private set; }

    public string GetFullName()
        => MiddleName != null
            ? $"{LastName} {FirstName} {MiddleName}"
            : $"{LastName} {FirstName}";

    public FullName Update(string? firstName, string? lastName, string? middleName)
    {
        if (firstName != null)
            FirstName = firstName;
        if (lastName != null)
            LastName = lastName;
        if (middleName != null)
            MiddleName = middleName;
        new FullNameValidator(nameof(FullName)).ValidateWithErrors(this);
        return this;
    }
}