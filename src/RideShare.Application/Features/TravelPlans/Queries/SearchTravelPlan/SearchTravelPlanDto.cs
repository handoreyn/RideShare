namespace RideShare.Application.Features.TravelPlans.Queries.SearchTravelPlan;

public sealed record SearchTravelPlanDto(int Id, int SeatCount, string Description, bool IsActive, DateTime DepartureDateTime);