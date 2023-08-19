using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RideShare.Domain.Abstractions.Repositories;
using RideShare.Domain.Common;
using RideShare.Infrastructure.Persistence;

namespace RideShare.Infrastructure.Repositories;

public abstract class Repository<T> : IRepository<T> where T : EntityBase
{
    private readonly DatabaseContext _dbContext;
    protected Repository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(T entity, CancellationToken cancellationToken)
    {
        await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(int id, CancellationToken cancellationToken)
    {
        var entity = await FindById(id, cancellationToken);
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<T> Find(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
        return entity;
    }

    public async Task<List<T>> FindAll(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Set<T>().Where(predicate).ToListAsync(cancellationToken);
        return result;
    }

    public async Task<T> FindById(int id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id, cancellationToken);
        return entity;
    }

    public async Task Update(T entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}