using AutoMapper;
using RideShare.Application.Abstractions.Messaging;
using RideShare.Domain.Abstractions.Repositories;
using RideShare.Domain.Exceptions;
using RideShare.Domain.ValueObjects;

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
        var searchPlan = await _repository.FindAll(r => r.TravelPlanRoute.DepartureCity.Equals(request.DepartureCity) &&
            r.TravelPlanRoute.DestinationCity.Equals(request.DestinationCity), cancellationToken);

        if (searchPlan == null || !searchPlan.Any()) throw new EntityDoesNotExistException($"No travel plan exist according to {request.DepartureCity} and {request.DestinationCity}");
        
        var plansToReturn = _mapper.Map<List<SearchTravelPlanDto>>(searchPlan);
        return plansToReturn;
    }
}