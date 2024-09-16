using System.Reflection;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Shared.Application.Behaviors;

internal sealed class ValidationPipelineBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        ValidationFailure[] validationFailures = await ValidateAsync(request, cancellationToken);

        if (validationFailures.Any())
        {
            if (typeof(TResponse).IsGenericType && typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
            {
                Type responseType = typeof(TResponse).GetGenericArguments()[0];

                MethodInfo? failureMethod = typeof(Result<>)
                    .MakeGenericType(responseType)
                    .GetMethod(nameof(Result<object>.ValidationResult));

                if (failureMethod is not null)
                {
                    return (TResponse)failureMethod.Invoke(null, [CreateValidationError(validationFailures)]);
                }
            }else if (typeof(TResponse) == typeof(Result))
            {
                return (TResponse)(object)Result.Failure(CreateValidationError(validationFailures));
            }

            throw new ValidationException(validationFailures);
        }

        return await next();
    }

    private async Task<ValidationFailure[]> ValidateAsync(TRequest request, CancellationToken cancellationToken)
    {
        ValidationFailure[] validationFailures = Array.Empty<ValidationFailure>();

        if (validators.Any())
        {
            var validationContext = new ValidationContext<TRequest>(request);

            ValidationResult[] validationResults = await Task.WhenAll(
                validators.Select(v
                    => v.ValidateAsync(validationContext, cancellationToken))
            );

            validationFailures = validationResults
                .Where(r => !r.IsValid)
                .SelectMany(r => r.Errors)
                .ToArray();
        }

        return validationFailures;
    }

    private ValidationError CreateValidationError(ValidationFailure[] validationFailures)
    {
        return new ValidationError(
            validationFailures.Select(v =>
                    new Error(
                        code: v.ErrorCode,
                        description: v.ErrorMessage,
                        ErrorType.Validation))
                .ToArray());
    }
}