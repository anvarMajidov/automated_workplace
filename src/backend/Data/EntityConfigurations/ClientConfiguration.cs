using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.DbModels;

namespace Data.EntityConfigurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Surname)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Patronymic)
            .IsRequired(false);

        builder.Property(p => p.Phone)
            .IsRequired();
        
        builder.HasMany(c => c.Cars)
            .WithOne(car => car.Client)
            .HasForeignKey(car => car.ClientId)
            .IsRequired();
    }
}
