using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.DbModels;

namespace Data.EntityConfigurations;

public class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
{
    public void Configure(EntityTypeBuilder<CarModel> builder)
    {
        builder.Property(b => b.Name)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.HasOne(c => c.Brand)
            .WithMany(b => b.CarModels)
            .HasForeignKey(c => c.BrandId)
            .IsRequired();

        builder.HasMany(c => c.Cars)
            .WithOne(c => c.CarModel)
            .IsRequired(false);
    }
}
