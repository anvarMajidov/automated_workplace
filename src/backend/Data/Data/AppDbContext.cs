using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Models.DbModels;

namespace Data.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }
    public DbSet<CarModel> CarModels { get; set; }
    public DbSet<CarBrand> CarBrands { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Master> Masters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
