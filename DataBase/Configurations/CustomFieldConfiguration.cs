using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations;

public class CustomFieldConfiguration : IEntityTypeConfiguration<CustomField<string>>
{
    public void Configure(EntityTypeBuilder<CustomField<string>> builder)
    {
        builder.ToTable("custom_field_string");
        
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.Name)
            .IsRequired()
            .HasColumnName("name");

        builder.Property(c => c.Value)
            .IsRequired()
            .HasColumnName("value");
    }
}