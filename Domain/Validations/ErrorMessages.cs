namespace Domain.Validations;

/// <summary>
/// Класс сообщений об ошибках
/// </summary>
public abstract class ErrorMessages
{
    /// <summary>
    /// Сообщение об ошибке некорректного формата номера телефона
    /// </summary>
    public const string PhoneFormat = "Номер телефона не корректный формат. Пример: +37377712345";

    /// <summary>
    /// Сообщение об ошибке некорректного формата никнейма телеграма
    /// </summary>
    public const string TelegramFormat = "Имя телеграмма должен быть правильного формата. Пример: @user_name";

    /// <summary>
    /// Сообщение об ошибке формата - только буквы
    /// </summary>
    public const string OnlyLetters = "{0} должен содержать только буквы";
    
    /// <summary>
    /// Сообщение об ошибке даты
    /// </summary>
    public const string FutureDate = "{0} не может быть в будущем";
    
    /// <summary>
    /// Сообщение об ошибке даты рождения
    /// </summary>
    /// <remarks>
    /// Использовать вместе со string.Format
    /// {0} - имя свойства
    /// </remarks>
    public const string OldDate = "{0} слишком старая дата";

    /// <summary>
    /// Сообщение об исключении null
    /// </summary>
    /// <remarks>
    /// Использовать вместе со string.Format
    /// {0} - имя свойства
    /// </remarks>
    public const string IsNull = "{0} is null";

    /// <summary>
    /// Сообщение об исключении empty
    /// </summary>
    /// <remarks>
    /// Использовать вместе со string.Format
    /// {0} - имя свойства
    /// </remarks>
    public const string IsEmpty = "{0} пустой";

}