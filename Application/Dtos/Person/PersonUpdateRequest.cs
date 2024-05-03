using Domain.Primitives.Enums;

namespace Application.Dtos.Person;

public class PersonUpdateRequest
{
    public Guid Id { get; init; }
    
    public string? FirstName { get; init; }

    public string? LastName { get; init; }
    
    public string? MiddleName { get; init; }
    public Gender? Gender { get; init; }

    public DateTime? BirthDate { get; init; }

    public string? PhoneNumber { get; init; }

    public string? Telegram { get; init; }
}
