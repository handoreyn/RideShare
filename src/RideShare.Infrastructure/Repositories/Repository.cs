using System.Linq.Expressions;
using RideShare.Domain.Abstractions.Repositories;
using RideShare.Domain.Common;

namespace RideShare.Infrastructure.Repositories;

public abstract class Repository<T> : IRepository<T> where T : EntityBase
{
    protected Repository()
    {
    }

    public Task Create(T entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<T> Find(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> FindAll(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<T> FindById(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(T entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}