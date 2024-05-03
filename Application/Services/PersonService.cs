using Application.Dtos.Person;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class PersonService(
    IPersonRepository personRepository,
    IMapperBase mapper)
{
    public async Task<PersonGetAllResponse> GetAll(PersonGetAllFilterRequest? filterRequest = null)
    {
        var persons = await personRepository.GetAll();
        if (filterRequest != null)
        {
            if (filterRequest.Search != null)
                persons = persons.Where(p => p.FullName.FirstName.Contains(filterRequest.Search));

            if (filterRequest.Gender != null)
                persons = persons.Where(p => p.Gender == filterRequest.Gender);

            if (filterRequest.AgeFrom != null)
                persons = persons.Where(p => p.Age >= filterRequest.AgeFrom);

            if (filterRequest.AgeTo != null)
                persons = persons.Where(p => p.Age <= filterRequest.AgeTo);
        }
        return mapper.Map<PersonGetAllResponse>(persons);
    }

    public async Task<PersonGetByIdResponse> GetById(Guid id)
        => mapper.Map<PersonGetByIdResponse>(await personRepository.GetByIdOrThrow(id));

    public async Task<PersonCreateResponse> Create(PersonCreateRequest personCreateRequest)
    {
        var person = mapper.Map<Person>(personCreateRequest);
        await personRepository.Create(person);
        return mapper.Map<PersonCreateResponse>(person);
    }

    public async Task<PersonUpdateResponse> Update(PersonUpdateRequest personUpdateRequest)
    {
        var person = await personRepository.GetByIdOrThrow(personUpdateRequest.Id);
        person.Update(
            personUpdateRequest.FirstName,
            personUpdateRequest.LastName,
            personUpdateRequest.MiddleName,
            personUpdateRequest.Gender,
            personUpdateRequest.BirthDate,
            personUpdateRequest.PhoneNumber,
            personUpdateRequest.Telegram);
        var personUpdated = await personRepository.Update(person);
        return mapper.Map<PersonUpdateResponse>(personUpdated);
    }

    public async Task Remove(Guid id)
        => await personRepository.Remove(id);
}