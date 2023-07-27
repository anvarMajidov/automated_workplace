using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.DbModels;

namespace Data.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasOne(c => c.CarBrand)
            .WithMany(b => b.Cars)
            .HasForeignKey(c => c.CarBrandId)
            .IsRequired();
        
        builder.HasOne(c => c.CarModel)
            .WithMany(cm => cm.Cars)
            .HasForeignKey(car => car.CarModelId)
            .IsRequired();
        
        builder.HasOne(c => c.Client)
            .WithMany()
            .HasForeignKey(c => c.ClientId)
            .IsRequired(false);

        builder.Property(c => c.ManufactureDate)
            .IsRequired();

        builder.Property(c => c.TransmissionType)
            .IsRequired();

        builder.Property(c => c.EnginePower)
            .IsRequired();
    }
}
