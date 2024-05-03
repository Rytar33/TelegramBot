using Domain.Primitives.Enums;

namespace Application.Dtos.Person;

public abstract class BasePersonDto
{
    public FullNameDto FullName { get; init; }

    public Gender Gender { get; init; }

    public DateTime BirthDate { get; init; }

    public string PhoneNumber { get; init; }

    public string Telegram { get; init; }
}
