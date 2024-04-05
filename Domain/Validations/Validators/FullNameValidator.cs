using Domain.Entities.ValueObjects;
using FluentValidation;

namespace Domain.Validations.Validators;

/// <summary>
/// Валидация Имени
/// </summary>
public class FullNameValidator : AbstractValidator<FullName>
{
    public FullNameValidator(string paramName)
    {
        RuleFor(fn => fn.GetFullName())
            .NotNull().WithMessage(string.Format(ErrorMessages.IsNull, paramName))
            .NotEmpty().WithMessage(string.Format(ErrorMessages.IsEmpty, paramName))
            .Matches(RegexPatterns.LfmPattern).WithMessage(string.Format(ErrorMessages.OnlyLetters, paramName));
    }
}