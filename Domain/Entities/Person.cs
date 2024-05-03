using Domain.Entities.ValueObjects;
using Domain.Primitives.Enums;
using Domain.Validations.Validators;
using Domain.Validations;

namespace Domain.Entities;

/// <summary>
/// Сущность человека
/// </summary>
public class Person : BaseEntity
{
    public Person(
        FullName fullName,
        Gender gender,
        DateTime birthDate,
        string phoneNumber,
        string telegram)
    {
        FullName = new FullNameValidator(nameof(birthDate)).ValidateWithErrors(fullName);
        Gender = gender;
        BirthDate = new BirthDateValidator(nameof(birthDate)).ValidateWithErrors(birthDate);
        PhoneNumber = new PhoneValidator(nameof(phoneNumber)).ValidateWithErrors(phoneNumber);
        Telegram = new TelegramValidator(nameof(telegram)).ValidateWithErrors(telegram);
    }
    
    /// <summary>
    /// Имя
    /// </summary>
    public FullName FullName { get; private set; }
    
    /// <summary>
    /// Гендер
    /// </summary>
    public Gender Gender { get; private set; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; private set; }

    /// <summary>
    /// Возраст
    /// </summary>
    public int Age 
        => DateTime.Now.Year - BirthDate.Year;

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; private set; }
    
    /// <summary>
    /// Никнейм в телеграм
    /// </summary>
    public string Telegram { get; private set; }

    public Person Update(FullName fullName)
    {
        FullName = this.FullName.Update(fullName.FirstName, fullName.LastName, fullName.MiddleName);
        return this;
    }
}