using RideShare.Application.Abstractions.Messaging;

namespace RideShare.Application.Features.TravelPlans.Commands.JoinTravelPlan;

public sealed record JoinTravelPlanCommand(int TravelPlanId) :ICommand;