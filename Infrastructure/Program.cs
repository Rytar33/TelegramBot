using Application.Dtos.Person;
using Application.Interfaces;
using Application.MappingProfiles;
using Application.Repositorys;
using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<IPersonRepository, PersonPostgreSQLRepository>();
        builder.Services.AddScoped<PersonService>();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapGet("api/v0/Person", async (PersonService personService) 
            => Results.Ok(await personService.GetAll()));
        app.MapGet("api/v0/Person/{id:guid}", async ([FromRoute] Guid id, PersonService personService) 
            => Results.Ok(await personService.GetById(id)));
        app.MapPost("api/v0/Person", async (PersonCreateRequest personCreateRequest, PersonService personService) 
            => Results.Ok(await personService.Create(personCreateRequest)));
        app.MapPut("api/v0/Person", async (PersonUpdateRequest personUpdateRequest, PersonService personService) 
            => Results.Ok(await personService.Update(personUpdateRequest)));
        app.MapDelete("api/v0/Person/{id:guid}", async ([FromRoute] Guid id, PersonService personService) 
            => Results.Ok(personService.Remove(id)));
        
        app.Run();
    }
}