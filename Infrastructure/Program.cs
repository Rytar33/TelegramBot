using Application.Interfaces;
using Application.Repositorys;
using Application.Services;

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
        
        
        app.Run();
    }
}