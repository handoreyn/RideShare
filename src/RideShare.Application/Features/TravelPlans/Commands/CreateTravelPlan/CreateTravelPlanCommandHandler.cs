using AutoMapper;
using RideShare.Application.Abstractions.Messaging;
using RideShare.Domain.Abstractions.Repositories;
using RideShare.Domain.Entities;

namespace RideShare.Application.Features.TravelPlans.Commands.CreateTravelPlan;

public class CreateTravelPlanCommandHandler : ICommandHandler<CreateTravelPlanCommand, int>
{
    private readonly ITravelPlanRepository _travelPlanRepository;
    private readonly IMapper _mapper;

    public CreateTravelPlanCommandHandler(ITravelPlanRepository travelPlanRepository, IMapper mapper)
    {
        _travelPlanRepository = travelPlanRepository ?? throw new ArgumentNullException(nameof(travelPlanRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<int> Handle(CreateTravelPlanCommand request, CancellationToken cancellationToken)
    {
        var travelPlan = _mapper.Map<TravelPlan>(request);
        travelPlan.IsActive = true;

        await _travelPlanRepository.Create(travelPlan, cancellationToken);
        return travelPlan.Id;
    }
}
