using FluentValidation;
using RideShare.Application.Features.TravelPlans.Commands.UpdateTravelPlanStatus;

namespace RideShare.Application.Features.TravelPlans.Commands.UpdateTravelPlan;

public sealed class UpdateTravelPlanStatusCommandValidator : AbstractValidator<UpdateTravelPlanStatusCommand>
{
    public UpdateTravelPlanStatusCommandValidator()
    {
        RuleFor(r => r.TravelPlanId)
            .GreaterThan(0)
            .WithMessage("TravelPlanId must be greater than 0.")
            .NotEmpty()
            .WithMessage("TravelPlanId can not be empty.");
    }
}