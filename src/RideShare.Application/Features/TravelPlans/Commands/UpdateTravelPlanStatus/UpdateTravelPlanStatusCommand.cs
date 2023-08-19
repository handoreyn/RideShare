
using RideShare.Application.Abstractions.Messaging;

namespace RideShare.Application.Features.TravelPlans.Commands.UpdateTravelPlanStatus;

public sealed record UpdateTravelPlanStatusCommand(int TravelPlanId, bool Status) : ICommand;