using DataBase.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase;

public class TelegramBotDbContext : DbContext
{
    public TelegramBotDbContext() { }
    
    public DbSet<Person> Person { get; set; }
    
    public DbSet<CustomField<string>> CustomField { get; set; }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=telegram_bot_test;UserName=postgres;Password=postgres");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new CustomFieldConfiguration());
    }
}