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

    public async ValueTask<IReadOnlyList<TEntity>> GetPagedResponseAsync(int pageNumber, int pageSize,
        Expression<Func<TEntity, bool>> expression)
    {
        var data = await _context
            .Set<TEntity>()
            .AsNoTracking()
            .Where(expression)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return data;
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

    public async ValueTask<TEntity> DeleteAsync(TEntity entity)
    {
        var entry = _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();

        return entry.Entity;
    }

    public async ValueTask<TEntity> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        var delEntity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);

        if (delEntity is null) throw new ApplicationException("Information or Entity entry not found");

        var entry = _context.Set<TEntity>().Remove(delEntity);
        await _context.SaveChangesAsync();

        return entry.Entity;
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
            .AsNoTracking()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return data;
    }

    public async ValueTask<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return entity;
    }
}