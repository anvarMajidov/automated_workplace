using Data.Data;
using Data.Repositories;
using Models.DbModels;

namespace Logic.Repositories;

public class CarBrandsRepository : BaseRepository<CarBrand>, ICarBrandsRepository
{
    public CarBrandsRepository(AppDbContext context) : base(context) {}
}