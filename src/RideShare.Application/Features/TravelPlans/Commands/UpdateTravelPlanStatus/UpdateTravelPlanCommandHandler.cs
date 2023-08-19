using RideShare.Application.Abstractions.Messaging;
using RideShare.Domain.Abstractions.Repositories;
using RideShare.Domain.Exceptions;

namespace RideShare.Application.Features.TravelPlans.Commands.UpdateTravelPlanStatus;

public sealed class UpdateTravelPlanStatusCommandHandler : ICommandHandler<UpdateTravelPlanStatusCommand>
{
    private readonly ITravelPlanRepository _travelPlanRepository;

    public UpdateTravelPlanStatusCommandHandler(ITravelPlanRepository travelPlanRepository)
    {
        _travelPlanRepository = travelPlanRepository ?? throw new ArgumentNullException(nameof(travelPlanRepository));
    }

    public async Task Handle(UpdateTravelPlanStatusCommand request, CancellationToken cancellationToken)
    {
        var travelPlan = await _travelPlanRepository.FindById(request.TravelPlanId, cancellationToken) ??
            throw new EntityDoesNotExistException($"Travel Plan with Id: {request.TravelPlanId} does not exist.");

        travelPlan.IsActive = request.Status;

        await _travelPlanRepository.Update(travelPlan, cancellationToken);
    }
}
