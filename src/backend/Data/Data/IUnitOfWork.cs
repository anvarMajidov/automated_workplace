using Data.Repositories;

namespace Data.Data;

public interface IUnitOfWork
{
    public IClientsRepository ClientsRepository { get; }
    public ICarsRepository CarsRepository { get; }
    public IMastersRepository MasterRepository { get; }
    public ICarModelsRepository CarModelsRepository { get; }
    public ICarBrandsRepository CarBrandsRepository { get; }

    public bool SaveChanges();
    public Task<bool> SaveChangesAsync();
}