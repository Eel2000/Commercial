using System.Linq.Expressions;
using Commercial.Domain.Repositories.Interfaces;
using Commercial.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Commercial.Persistence.Repositories;

public class GenericRepositoryAsync<TEntity> : IGenericRepositoryAsync<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;

    public GenericRepositoryAsync(ApplicationDbContext context)
    {
        _context = context;
    }

    public async ValueTask<IReadOnlyList<TEntity>> GetPagedResponseV2Async(int pageNumber, int pageSize)
    {
        var data = _context
            .Set<TEntity>()
            .AsEnumerable()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        await Task.Delay(500);
        return data;
    }

    public async ValueTask<TEntity> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async ValueTask DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async ValueTask<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        => await _context.Set<TEntity>().FirstOrDefaultAsync(expression);

    public async ValueTask<IReadOnlyList<TEntity>> ToListAsync()
        => await _context.Set<TEntity>().ToListAsync();

    public async ValueTask<IReadOnlyList<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> expression)
        => await _context.Set<TEntity>().Where(expression).ToListAsync();

    public async ValueTask<IReadOnlyList<TEntity>> GetPagedResponseAsync(int pageNumber, int pageSize)
    {
        var data = await _context
            .Set<TEntity>()
            .AsQueryable()
            .AsNoTracking()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return data;
    }

    public async ValueTask UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}