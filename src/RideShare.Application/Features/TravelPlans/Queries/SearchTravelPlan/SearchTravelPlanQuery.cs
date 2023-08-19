using RideShare.Application.Abstractions.Messaging;

namespace RideShare.Application.Features.TravelPlans.Queries.SearchTravelPlan;

public sealed record SearchTravelPlanQuery(string DepartureCity, string DestinationCity) : IQuery<List<SearchTravelPlanDto>>;