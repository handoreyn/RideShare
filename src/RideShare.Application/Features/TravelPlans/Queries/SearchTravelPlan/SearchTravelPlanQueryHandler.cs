using AutoMapper;
using RideShare.Application.Abstractions.Messaging;
using RideShare.Domain.Abstractions.Repositories;

namespace RideShare.Application.Features.TravelPlans.Queries.SearchTravelPlan;

public sealed class SearchTravelPlanQueryHandler : IQueryHandler<SearchTravelPlanQuery, List<SearchTravelPlanDto>>
{
    private readonly ITravelPlanRepository _repository;
    private readonly IMapper _mapper;

    public SearchTravelPlanQueryHandler(ITravelPlanRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<SearchTravelPlanDto>> Handle(SearchTravelPlanQuery request, CancellationToken cancellationToken)
    {
        var searchPlan = await _repository.FindAll(r => r.DepartureCity.Equals(request.DepartureCity) &&
            r.DestinationCity.Equals(request.DestinationCity) && r.IsActive && r.TravelDateTime > DateTime.Now, cancellationToken);

        var plansToReturn = _mapper.Map<List<SearchTravelPlanDto>>(searchPlan);
        return plansToReturn;
    }
}