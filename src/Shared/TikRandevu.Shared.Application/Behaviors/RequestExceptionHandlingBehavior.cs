using MediatR;
using Microsoft.Extensions.Logging;

namespace TikRandevu.Shared.Application.Behaviors;

public class RequestExceptionHandlingBehavior<TRequest, TResponse>(
    ILogger<RequestExceptionHandlingBehavior<TRequest, TResponse>> logger
    )
    
    : IPipelineBehavior<TRequest, TResponse>
    
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception e)
        {
            logger.LogError("Unhandling Exception Occured {RequestName}", typeof(TRequest).Name);
            throw new DomainException(typeof(TRequest).Name, innerException: e);
        }
    }
}