using FluentValidation;

namespace RideShare.Application.Features.TravelPlans.Commands.CreateTravelPlan;

public sealed class CreateTravelPlanCommandValidator : AbstractValidator<CreateTravelPlanCommand>
{
    public CreateTravelPlanCommandValidator()
    {
        RuleFor(p => p.Username)
            .NotEmpty()
            .WithMessage("Username can not be empty.");

        RuleFor(p => p.DepartureCity)
            .NotEmpty()
            .WithMessage("DepartureCity can not be empty.");

        RuleFor(p => p.Destination)
            .NotEmpty()
            .WithMessage("DestionationCity can not be empty.");

        RuleFor(p => p.TravelDateTime)
            .GreaterThan(DateTime.Now)
            .WithMessage("TravelDateTime must be greater than current date time.")
            .NotEmpty()
            .WithMessage("TravelDateTime can not be empty.");

        RuleFor(p => p.SeatCount)
            .GreaterThan(0)
            .WithMessage("SeatCount must be greater than 0.")
            .NotEmpty()
            .WithMessage("SeatCount can not be empty.");

    }
}