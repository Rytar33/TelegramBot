using FluentValidation;

namespace Domain.Validations.Validators;

/// <summary>
/// Валидация дня рождения
/// </summary>
public class BirthDateValidator : AbstractValidator<DateTime>
{
    public BirthDateValidator(string paramName)
    {
        RuleFor(d => d)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.IsEmpty, paramName))
            .GreaterThan(DateTime.Now.AddYears(-120)).WithMessage(string.Format(ErrorMessages.OldDate, paramName))
            .LessThan(DateTime.Now).WithMessage(string.Format(ErrorMessages.FutureDate, paramName));
    }
}