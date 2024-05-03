namespace Application.Dtos.Person;

public class PersonGetAllResponse
{
    public IEnumerable<PersonGetByIdResponse> Persons { get; init; }
}
