using System.Linq.Expressions;
using Data.Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Models.DbModels;

namespace Logic.Repositories;

public class ClientsRepository : BaseRepository<Client>, IClientsRepository
{
    private readonly AppDbContext _context;
    public ClientsRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
