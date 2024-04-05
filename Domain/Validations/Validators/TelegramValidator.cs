using FluentValidation;

namespace Domain.Validations.Validators;

/// <summary>
/// Валидация никнейма в телеграмм
/// </summary>
public class TelegramValidator : AbstractValidator<string>
{
    public TelegramValidator(string paramName)
    {
        RuleFor(t => t)
            .NotNull().WithMessage(string.Format(ErrorMessages.IsNull, paramName))
            .NotEmpty().WithMessage(string.Format(ErrorMessages.IsEmpty, paramName))
            .Matches(RegexPatterns.TelegramPattern).WithMessage(ErrorMessages.TelegramFormat);
    }
}