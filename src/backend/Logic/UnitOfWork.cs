using Data.Data;
using Data.Repositories;
using Logic.Repositories;

namespace Logic;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    
    public IClientsRepository ClientsRepository => new ClientsRepository(_context);
    public ICarsRepository CarsRepository => new CarsRepository(_context);
    public IMastersRepository MasterRepository => new MastersRepository(_context);
    public ICarModelsRepository CarModelsRepository => new CarModelsRepository(_context);
    public ICarBrandsRepository CarBrandsRepository => new CarBrandsRepository(_context);
    
    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }
    
    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    #region IDisposable region

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        
        if (disposing)
        {
            _context.Dispose();
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
