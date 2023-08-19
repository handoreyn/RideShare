using System.Linq.Expressions;
using RideShare.Domain.Common;

namespace RideShare.Domain.Abstractions.Repositories;

/// <summary>
/// Defines <c>IRepository<T></c> to implement generic repository
/// </summary>
public interface IRepository<T> where T : EntityBase
{
    public Task<T> FindById(int id, CancellationToken cancellationToken);
    public Task<T> Find(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    public Task<List<T>> FindAll(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);

    public Task Create(T entity, CancellationToken cancellationToken);
    public Task Update(T entity, CancellationToken cancellationToken);
    public Task Delete(int id, CancellationToken cancellationToken);
}