using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.DbModels;

namespace Data.EntityConfigurations;

public class MasterConfiguration : IEntityTypeConfiguration<Master>
{
    public void Configure(EntityTypeBuilder<Master> builder)
    {
        builder.Property(m => m.Surname)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(m => m.Name)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(m => m.Patronymic)
            .HasMaxLength(255)
            .IsRequired(false);
        
        builder.HasMany(m => m.Cars)
            .WithMany(c => c.Masters);
    }
}
