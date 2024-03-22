using System.ComponentModel.DataAnnotations;
using Domain.ValueObjects;

namespace Domain.Entities;
/// <summary>
/// Человек
/// </summary>
public class Person : BaseEntity
{
    public Person(
        FullName fullName,
        DateTime birthDate, 
        string numberPhone, 
        string telegram)
    {
        ValidateBirthDay(birthDate);
        ValidateNumberPhone(numberPhone);
        ValidateTelegram(telegram);
        FullName = ValidateFullName(fullName);
        BirthDate = birthDate;
        NumberPhone = numberPhone;
        Telegram = telegram;
    }
    /// <summary>
    /// ФИО
    /// </summary>
    public FullName FullName { get; init; }
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; init; }
    /// <summary>
    /// Возраст
    /// </summary>
    public int Age 
        => DateTime.UtcNow.Year - BirthDate.Year;
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string NumberPhone { get; init; }
    /// <summary>
    /// Имя пользователя в телеграмме
    /// </summary>
    public string Telegram { get; init; }
    /// <summary>
    /// Валидация даты рождения
    /// </summary>
    /// <param name="birthDay">Параметр datetime, который валидируется</param>
    /// <exception cref="ValidationException"></exception>
    public void ValidateBirthDay(DateTime birthDay)
    {
        switch (DateTime.UtcNow.Year - birthDay.Year)
        {
            case < 16:
                throw new ValidationException("Пользователь должен быть старше 16 лет");
            case > 120:
                throw new ValidationException("Пользователю не может быть больше 120 лет");
        }
    }
    /// <summary>
    /// Валидация номера телефона
    /// </summary>
    /// <param name="numberPhone">Номер телефона</param>
    /// <exception cref="ValidationException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public void ValidateNumberPhone(string numberPhone)
    {
        if (!numberPhone.StartsWith("+373"))
            throw new ValidationException();
        if (numberPhone.Length != 12)
            throw new ArgumentOutOfRangeException();
        if (numberPhone.Any(n => !char.IsNumber(n) && n != '+') || numberPhone.Count(n => n == '+') > 1)
            throw new ArgumentException("");
    }
    /// <summary>
    /// Валидация имени пользователя в телеграмме
    /// </summary>
    /// <param name="telegram">Параметр который принимает имя пользователя телеграмма</param>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void ValidateTelegram(string telegram)
    {
        if (!telegram.StartsWith('@'))
            throw new ArgumentException("В имени телеграмма должно идти как минимум сначало знак \"@\"");
        if (telegram.Length < 6 | telegram.Length > 33)
            throw new ArgumentOutOfRangeException("Размер имени телеграмма " +
                                                  "должен быть в диапозоне от 6 до 33 символов");
        if (telegram.Any(t => !char.IsLetter(t) 
                              && !char.IsNumber(t) 
                              && !char.IsSurrogate(t)))
            throw new ArgumentException("В имени телеграмма должны быть только цифры 0-9, " +
                                        "латинские буквы a-z A-Z, либо знак подчеркивания");
    }
    /// <summary>
    /// Валидация ФИО
    /// </summary>
    /// <param name="fullName">Принимает в параметры класс ФИО</param>
    /// <returns>Возвращает полное ФИО при успешной валидации</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ArgumentException"></exception>
    private FullName ValidateFullName(FullName fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName.FirstName)
            | string.IsNullOrWhiteSpace(fullName.LastName))
            throw new ArgumentNullException("Имя и/или фамилия не должны быть пустыми!");
        if (fullName.FirstName.Length > 50 
            | fullName.LastName.Length > 50)
            throw new ArgumentOutOfRangeException("Имя и/или фамилия не может быть длинее 50 символов");
        if (fullName.FirstName.Any(f => !char.IsLetter(f)) 
            && fullName.LastName.Any(l => !char.IsLetter(l)))
            throw new ArgumentException("В имени и/или фамилии содержаться недопустимые символы");
        if (fullName.MiddleName != null)
        {
            if (fullName.MiddleName == string.Empty)
                throw new ArgumentException("Отчество не может быть пустым");
            if (fullName.MiddleName.Length > 50)
                throw new ArgumentOutOfRangeException("Отчество не может быть длинее 50 символов");
            if (fullName.MiddleName.Any(m => !char.IsLetter(m)))
                throw new ArgumentException("В отчестве содержаться недопустимые символы");
        }
        return fullName;
    }
}