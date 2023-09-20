using Application.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            await HandlePossibleValidationIssues(request, cancellationToken);
        }

        return await next();
    }

    private async Task HandlePossibleValidationIssues(TRequest request, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationResults =
            await Task.WhenAll(_validators.Select(validator =>
                validator.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .Where(validationResult => validationResult.Errors.Any())
            .SelectMany(validationResult => validationResult.Errors)
            .ToList();

        if (failures.Any())
        {
            throw new CustomValidationException(failures);
        }
    }
}