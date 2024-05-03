using Application.Interfaces;
using Domain.Entities;

namespace Application.Repositorys
{
    public class PersonPostgreSQLRepository : IPersonRepository
    {
        public async Task<Person> Create(Person person)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Person> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomField<string>>> GetCustomFields()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
