using Domain.Entities;

namespace Application.Interfaces;

public interface IPersonRepository : IRepository<Person>
{
    Task<IEnumerable<CustomField<string>>> GetCustomFields();
}