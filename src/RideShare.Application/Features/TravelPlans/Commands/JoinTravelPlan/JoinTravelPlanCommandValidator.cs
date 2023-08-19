using FluentValidation;

namespace RideShare.Application.Features.TravelPlans.Commands.JoinTravelPlan;

public sealed class JoinTravelPlanCommandValidator : AbstractValidator<JoinTravelPlanCommand>
{
    public JoinTravelPlanCommandValidator()
    {
        RuleFor(r => r.TravelPlanId)
            .GreaterThan(0)
            .WithMessage("TravelPlanId must be greater than 0.")
            .NotEmpty()
            .WithMessage("TravelPlanId can not be empty.");
    }
}