using RideShare.Application.Abstractions.Messaging;

namespace RideShare.Application.Features.TravelPlans.Commands.CreateTravelPlan;

public sealed record CreateTravelPlanCommand : ICommand<int>
{
    public string Username { get; set; }
    public string DepartureCity { get; set; }
    public string Destination { get; set; }
    public string Description { get; set; }
    public DateTime TravelDateTime { get; set; }
    public int SeatCount { get; set; }
}