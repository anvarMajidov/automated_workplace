using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.DbModels;

namespace Data.EntityConfigurations;

public class CarBrandConfiguration : IEntityTypeConfiguration<CarBrand>
{
    public void Configure(EntityTypeBuilder<CarBrand> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .HasMany(p => p.CarModels)
            .WithOne()
            .IsRequired(false);
        
        builder.HasMany(p => p.Cars)
            .WithOne()
            .IsRequired(false);
    }
}
