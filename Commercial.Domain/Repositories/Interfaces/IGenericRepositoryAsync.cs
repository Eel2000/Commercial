using System.Linq.Expressions;

namespace Commercial.Domain.Repositories.Interfaces;

public interface IGenericRepositoryAsync<TEntity> where TEntity : class
{
    ValueTask<IReadOnlyList<TEntity>> ToListAsync();
    ValueTask<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
    ValueTask<IReadOnlyList<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> expression);
    ValueTask<IReadOnlyList<TEntity>> GetPagedResponseAsync(int pageNumber, int pageSize);
    ValueTask<IReadOnlyList<TEntity>> GetPagedResponseV2Async(int pageNumber, int pageSize);
    ValueTask<TEntity> AddAsync(TEntity entity);
    ValueTask UpdateAsync(TEntity entity);
    ValueTask DeleteAsync(TEntity entity);
}