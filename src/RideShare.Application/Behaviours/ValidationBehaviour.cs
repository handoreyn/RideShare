using FluentValidation;
using MediatR;

namespace RideShare.Application.Behaviours;

public sealed class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators ?? throw new ArgumentNullException(nameof(validators));
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next();

        var validationContext = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(validationContext, cancellationToken)));

        var validationFailures = validationResults
            .SelectMany(t => t.Errors)
            .Where(p => p != null)
            .ToList();

        if (validationFailures.Count > 0) throw new ValidationException(validationFailures);

        return await next();
    }
}
