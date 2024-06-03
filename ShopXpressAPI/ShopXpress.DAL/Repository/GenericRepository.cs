using Microsoft.EntityFrameworkCore;
using ShopXpress.DAL.Configurations;
using ShopXpress.DAL.IRepository;
using ShopXpress.DAL.Models;
using ShopXpress.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ShopXpress.DAL.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
{
    public readonly ShopXpressDbContext _context;
    private readonly DbSet<T> _dbSet;
    
    public GenericRepository(ShopXpressDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    
    public virtual async Task Delete(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));
        
        var entity = await _dbSet.FindAsync(id);
        _dbSet.Remove(entity);
    }

    public void DeleteRange(IEnumerable<T>? entities)
    {
        if (entities == null) throw new ArgumentNullException(nameof(entities));
        
        _dbSet.RemoveRange(entities);
    }

    public async Task<T> Get(Expression<Func<T, bool>>? expression, List<string>? includes = null)
    {
        IQueryable<T> query = _dbSet;
        if (includes != null)
        {
            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }
        }
        return await query.AsNoTracking().FirstOrDefaultAsync(expression);
    }

    public async Task<IList<T>> GetAll(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<string>? includes = null)
    {
        IQueryable<T> query = _dbSet;
        if (expression != null)
        {
            query = query.Where(expression);
        }
        if (includes != null)
        {
            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }
        }
        if (orderBy != null)
        {
            query = orderBy(query);
        }
        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<IPagedList<T>> GetPagedList(RequestParams requestParams, List<string>? includes = null)
    {
        IQueryable<T> query = _dbSet;

        if (includes != null)
        {
            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }
        }

        return await query.AsNoTracking()
            .ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);
    }

    public virtual async Task Insert(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        
        entity.Id = Guid.NewGuid();
        await _dbSet.AddAsync(entity);
    }

    public async Task InsertRange(IEnumerable<T>? entities)
    {
        if (entities == null) throw new ArgumentNullException(nameof(entities));
        
        entities.Select(entity => entity.Id = Guid.NewGuid());
        await _dbSet.AddRangeAsync(entities);
    }

    public virtual void Update(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
}
