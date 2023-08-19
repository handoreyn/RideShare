using RideShare.Application.Abstractions.Messaging;

namespace RideShare.Application.Features.TravelPlans.Queries.FindTravelPlanById;

public sealed record FindTravelPlanByIdQuery(int Id) : IQuery<SearchTravelPlan.SearchTravelPlanDto>;