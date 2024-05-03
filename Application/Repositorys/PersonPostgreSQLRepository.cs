using Application.Interfaces;
using DataBase;
using Domain.Entities;
using Domain.Primitives.Enums;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositorys
{
    public class PersonPostgreSQLRepository : IPersonRepository
    {
        public PersonPostgreSQLRepository()
            => _db = new TelegramBotDbContext();

        private TelegramBotDbContext _db;

        public async Task<Person> Create(Person person)
        {
            await ValidationPerson(person, Operation.Create);
            await _db.Person.AddAsync(person);
            return person;
        }

        public Task<IEnumerable<Person>> GetAll()
            => Task.FromResult(_db.Person.AsEnumerable());

        public async Task<Person> GetByIdOrThrow(Guid id)
            => await _db.Person.FirstAsync(p => p.Id == id);

        public async Task<IEnumerable<CustomField<string>>> GetCustomFields()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(Guid id)
        {
            try
            {
                var person = await GetByIdOrThrow(id);
                await ValidationPerson(person, Operation.Delete);
                _db.Person.Remove(person);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public async Task<Person> Update(Person person)
        {
            await ValidationPerson(person, Operation.Update);
            _db.Person.Update(person);
            return person;
        }

        private async Task ValidationPerson(Person person, Operation operation)
        {
            switch (operation)
            {
                case Operation.Create:
                case Operation.Update:
                    if (await _db.Person.AnyAsync(p => p.FullName == person.FullName))
                        throw new DbUpdateException("Данное ФИО уже используется");
                    if (await _db.Person.AnyAsync(p => p.Telegram == person.Telegram))
                        throw new DbUpdateException("Данное имя в телеграмме уже используется");
                    if (await _db.Person.AnyAsync(p => p.PhoneNumber == person.PhoneNumber))
                        throw new DbUpdateException("Данный номер телефона уже используется");
                    break;
            }
        }
    }
}
