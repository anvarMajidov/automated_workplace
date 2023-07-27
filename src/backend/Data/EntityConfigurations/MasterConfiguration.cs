using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.DbModels;

namespace Data.EntityConfigurations;

public class MasterConfiguration : IEntityTypeConfiguration<Master>
{
    public void Configure(EntityTypeBuilder<Master> builder)
    {
        builder.Property(m => m.Surname).IsRequired();
        builder.Property(m => m.Name).IsRequired();
        builder.Property(m => m.Patronymic).IsRequired(false);
    }
}
