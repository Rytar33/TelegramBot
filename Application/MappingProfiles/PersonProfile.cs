using Application.Dtos.Person;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.ValueObjects;

namespace Application.MappingProfiles;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        #region Responses Map
        CreateMap<Person, PersonGetByIdResponse>()
            .ForMember(member => member.FullName,
                opt => opt.MapFrom(src => src.FullName));

        CreateMap<Person, PersonCreateResponse>()
            .ForMember(member => member.FullName,
                opt => opt.MapFrom(src => src.FullName));

        CreateMap<Person, PersonUpdateResponse>()
            .ForMember(member => member.FullName,
                opt => opt.MapFrom(src => src.FullName));

        CreateMap<IEnumerable<Person>, PersonGetAllResponse>()
            .ForMember(member => member.Persons.Select(p => p.FullName),
                opt => opt.MapFrom(src => src.Select(p => p.FullName)));
        #endregion

        #region Requests Map
        CreateMap<PersonCreateRequest, Person>()
            .ConstructUsing(dto => new Person(
                new FullName(dto.FullName.FirstName, dto.FullName.LastName, dto.FullName.MiddleName),
                dto.Gender,
                dto.BirthDate,
                dto.PhoneNumber,
                dto.Telegram));
        #endregion
    }
}