using Application.Dtos.Person;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class PersonService(
    IPersonRepository personRepository,
    IMapper mapper)
{
    private readonly IPersonRepository _personRepository = personRepository;

    private readonly IMapper _mapper = mapper;

    public async Task<PersonGetAllResponse> GetAll(PersonGetAllFilterRequest? filterRequest = null)
    {
        var persons = await _personRepository.GetAll();
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
        return _mapper.Map<PersonGetAllResponse>(persons);
    }

    public async Task<PersonGetByIdResponse> GetById(Guid id)
        => _mapper.Map<PersonGetByIdResponse>(await _personRepository.GetById(id));

    public async Task<PersonCreateResponse> Create(PersonCreateRequest personCreateRequest)
    {
        var person = _mapper.Map<Person>(personCreateRequest);
        await _personRepository.Create(person);
        return _mapper.Map<PersonCreateResponse>(person);
    }

    public async Task<PersonUpdateResponse> Update(PersonUpdateRequest personUpdateRequest)
    {
        await GetById(personUpdateRequest.Id);
        var person = await _personRepository.Update(_mapper.Map<Person>(personUpdateRequest));
        return _mapper.Map<PersonUpdateResponse>(person);
    }

    public async Task Remove(Guid id)
        => await _personRepository.Remove(GetById(id).GetAwaiter().GetResult().Id);
}