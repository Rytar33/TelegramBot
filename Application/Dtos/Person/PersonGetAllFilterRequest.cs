using Domain.Primitives.Enums;

namespace Application.Dtos.Person;

public class PersonGetAllFilterRequest
{
    public string? Search { get; init; }

    public Gender? Gender { get; init; }

    public int? AgeFrom { get; init; }

    public int? AgeTo { get; init; }
}
