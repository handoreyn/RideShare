using RideShare.Application.Abstractions.Messaging;
using RideShare.Domain.Abstractions.Repositories;

namespace RideShare.Application.Features.TravelPlans.Queries.SearchTravelPlan;

public sealed class SearchTravelPlanQueryHandler : IQueryHandler<SearchTravelPlanQuery, SearchTravelPlanDto>
{
    private readonly ITravelPlanRepository _repository;

    public SearchTravelPlanQueryHandler(ITravelPlanRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public Task<SearchTravelPlanDto> Handle(SearchTravelPlanQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}