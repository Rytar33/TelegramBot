namespace Application.Dtos.Person;

public class PersonGetByIdResponse : BasePersonDto
{
    public Guid Id { get; init; }
}