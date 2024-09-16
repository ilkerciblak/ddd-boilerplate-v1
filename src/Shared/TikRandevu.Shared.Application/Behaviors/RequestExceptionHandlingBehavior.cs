using MediatR;

namespace TikRandevu.Shared.Application.Behaviors;

public class RequestExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    
{
    
    // TODO: Implement Logging 
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new DomainException(typeof(TRequest).Name, innerException: e);
        }
    }
}