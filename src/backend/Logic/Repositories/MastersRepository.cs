using Data.Data;
using Data.Repositories;
using Models.DbModels;

namespace Logic.Repositories;

public class MastersRepository : BaseRepository<Master>, IMastersRepository
{
    private readonly AppDbContext _context;
    
    public MastersRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
