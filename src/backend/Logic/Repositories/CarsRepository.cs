using Data.Data;
using Data.Repositories;
using Models.DbModels;

namespace Logic.Repositories;

public class CarsRepository : BaseRepository<Car>, ICarsRepository
{
    public CarsRepository(AppDbContext context) : base(context) {}
}
