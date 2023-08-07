using Data.Data;
using Data.Repositories;
using Models.DbModels;

namespace Logic.Repositories;

public class CarModelsRepository : BaseRepository<CarModel>, ICarModelsRepository
{
    public CarModelsRepository(AppDbContext context) : base(context)
    {
    }
}