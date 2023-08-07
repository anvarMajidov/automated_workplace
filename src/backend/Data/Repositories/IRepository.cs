using System.Linq.Expressions;
using Models.DbModels;
using Models.HelperModels;

namespace Data.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAllAsync();
    IQueryable<T> GetQueryable(Expression<Func<T, bool>> expression);
    IQueryable<T> GetOrderedQuery(string? orderBy);
    IQueryable<T> GetFilteredQuery(Filter? filter);
    Task<T?> GetAsync(Guid id);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}
