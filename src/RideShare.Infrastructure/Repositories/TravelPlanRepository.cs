using RideShare.Domain.Abstractions.Repositories;
using RideShare.Domain.Entities;
using RideShare.Infrastructure.Persistence;

namespace RideShare.Infrastructure.Repositories;

public sealed class TravelPlanRepository : Repository<TravelPlan>, ITravelPlanRepository
{
    public TravelPlanRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }
}