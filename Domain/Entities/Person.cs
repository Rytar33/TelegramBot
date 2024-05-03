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
    /// <summary>
    /// Не использовать пустой конструктор! Он нужен для миграции в ORM системе
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public Person() => throw new ArgumentNullException();
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

    public List<CustomField<string>> CustomFields { get; private set; }
    
    public Person Update(
        string? firstName = null,
        string? lastName = null,
        string? middleName = null,
        Gender? gender = null, 
        DateTime? birthDate = null,
        string? phoneNumber = null,
        string? telegram = null)
    {
        FullName = FullName.Update(firstName, lastName, middleName);
        if (gender != null)
            Gender = gender.Value;
        if (birthDate != null)
            BirthDate = new BirthDateValidator(nameof(birthDate)).ValidateWithErrors(birthDate.Value);
        if (phoneNumber != null)
            PhoneNumber = new PhoneValidator(nameof(phoneNumber)).ValidateWithErrors(phoneNumber);
        if (telegram != null)
            Telegram = new TelegramValidator(nameof(telegram)).ValidateWithErrors(telegram);
        return this;
    }
}