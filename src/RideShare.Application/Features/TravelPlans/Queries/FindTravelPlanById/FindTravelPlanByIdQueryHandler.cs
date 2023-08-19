using AutoMapper;
using RideShare.Application.Abstractions.Messaging;
using RideShare.Application.Features.TravelPlans.Queries.SearchTravelPlan;
using RideShare.Domain.Abstractions.Repositories;
using RideShare.Domain.Entities;
using RideShare.Domain.Exceptions;

namespace RideShare.Application.Features.TravelPlans.Queries.FindTravelPlanById;

public sealed class FindTravelPlanByIdQueryHandler : IQueryHandler<FindTravelPlanByIdQuery, SearchTravelPlan.SearchTravelPlanDto>
{
    private readonly ITravelPlanRepository _repository;
    private readonly IMapper _mapper;

    public FindTravelPlanByIdQueryHandler(ITravelPlanRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
    }

    public async Task<SearchTravelPlanDto> Handle(FindTravelPlanByIdQuery request, CancellationToken cancellationToken)
    {
        var travelPlan = await _repository.FindById(request.Id, cancellationToken) ??
            throw new EntityDoesNotExistException($"Travel plan with id: {request.Id} does not exist");

        var result = _mapper.Map<SearchTravelPlanDto>(travelPlan);

        return result;
    }
}
