using FluentValidation;

namespace RideShare.Application.Features.TravelPlans.Queries.FindTravelPlanById;

public sealed class FindTravelPlanByIdQueryValidator : AbstractValidator<FindTravelPlanByIdQuery>
{
    public FindTravelPlanByIdQueryValidator()
    {
        RuleFor(r=> r.Id)
        .GreaterThan(0)
        .WithMessage("Id must be greater than 0")
        .NotEmpty()
        .WithMessage("Id can not be empty");
    }
}