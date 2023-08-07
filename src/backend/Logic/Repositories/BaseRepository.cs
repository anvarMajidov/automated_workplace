using System.Linq.Expressions;
using System.Reflection;
using Data.Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Models.DbModels;
using Models.HelperModels;

namespace Logic.Repositories;

public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;

    protected BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
    
    public IQueryable<T> GetQueryable(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public IQueryable<T> GetOrderedQuery(string? orderBy)
    {
        if (string.IsNullOrEmpty(orderBy)) return _context.Set<T>();
        
        //only public and non-static properties can be obtained
        var propertyInfo = typeof(T).GetProperty(orderBy, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
        if (propertyInfo == null)
        {
            throw new ArgumentException("Invalid order by property.", nameof(orderBy));
        }

        return _context.Set<T>().OrderBy(x => propertyInfo.GetValue(x, null));
    }
    
    public IQueryable<T> GetFilteredQuery(Filter? filter)
    {
        var query = _context.Set<T>().AsQueryable();
        
        if (filter == null || string.IsNullOrEmpty(filter.PropertyName) || string.IsNullOrEmpty(filter.PropertyValue))
        {
            return query;
        }
        
        //only public and non-static properties can be obtained
        var propertyInfo = typeof(T).GetProperty(filter.PropertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
        if (propertyInfo == null)
        {
            throw new ArgumentException("Invalid filter property name.", nameof(filter.PropertyName));
        }
        
        //create the filter expression
        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, propertyInfo);
        var value = Expression.Constant(Convert.ChangeType(filter.PropertyValue, propertyInfo.PropertyType));
        var equals = Expression.Equal(property, value);
        var func = Expression.Lambda<Func<T, bool>>(equals, parameter);
        
        return query.Where(func);
    }

    public async Task<T?> GetAsync(Guid id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
    
    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}
