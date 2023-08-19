using RideShare.Application.Abstractions.Messaging;
using RideShare.Domain.Abstractions.Repositories;
using RideShare.Domain.Exceptions;

namespace RideShare.Application.Features.TravelPlans.Commands.JoinTravelPlan;

public sealed class JoinTravelPlanCommandHandler : ICommandHandler<JoinTravelPlanCommand>
{
    private readonly ITravelPlanRepository _travelPlanRepository;

    public JoinTravelPlanCommandHandler(ITravelPlanRepository travelPlanRepository)
    {
        _travelPlanRepository = travelPlanRepository ?? throw new ArgumentNullException(nameof(travelPlanRepository));
    }

    public async Task Handle(JoinTravelPlanCommand request, CancellationToken cancellationToken)
    {
        var travelPlan = await _travelPlanRepository.FindById(request.TravelPlanId, cancellationToken) ??
            throw new EntityDoesNotExistException($"Travel Plan with Id: {request.TravelPlanId} does not exist.");

        travelPlan.SeatCount--;
        if (travelPlan.SeatCount < 0) throw new DomainException("Travel plan not available to join.");

        await _travelPlanRepository.Update(travelPlan, cancellationToken);
    }
}
