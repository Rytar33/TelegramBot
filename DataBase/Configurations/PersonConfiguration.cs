using Domain.Entities;
using Domain.Primitives.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("person");

        builder.HasKey(p => p.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.OwnsOne(p => p.FullName, fullName =>
        {
            fullName.Property(f => f.FirstName)
                .IsRequired()
                .HasColumnName("first_name");
            
            fullName.Property(f => f.LastName)
                .IsRequired()
                .HasColumnName("last_name");
            
            fullName.Property(f => f.MiddleName)
                .HasColumnName("middle_name");
        });
        
        builder.Property(p => p.Gender)
            .IsRequired()
            .HasDefaultValue(Gender.Unknown)
            .HasConversion<string>()
            .HasColumnName("gender");

        builder.Property(p => p.BirthDate)
            .IsRequired()
            .HasColumnType("timestamp")
            .HasColumnName("birth_date");

        builder.Property(p => p.PhoneNumber)
            .IsRequired()
            .HasColumnName("phone_number");
        
        builder.Property(p => p.Telegram)
            .IsRequired()
            .HasColumnName("telegram");

        builder.HasMany(p => p.CustomFields)
            .WithMany();
    }
}