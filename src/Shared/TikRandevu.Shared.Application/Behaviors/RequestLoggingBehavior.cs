using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Shared.Application.Behaviors;

public class RequestLoggingBehavior<TRequest, TResponse>(
    ILogger<RequestLoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TResponse : Result
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var moduleName = typeof(TRequest).FullName.Split(".")[2];

        using (LogContext.PushProperty("Module", moduleName))
        {
            logger.LogInformation("[START]-- Processing Request {RequestName}",requestName);
            
            var response = await next();

            if (response.IsFailure)
            {
                using (LogContext.PushProperty("Error", response.Error.ErrorType))
                {
                    logger.LogError("[ERROR] -- Error Occured with {ErrorType}, {Error}", response.Error.ErrorType, response.Error);
                }
                
            }else if (response.IsSuccess)
            {
                logger.LogInformation("[COMPLETED] -- Completed Request with Success {RequestName}", requestName);
            }
            
            return response;
        }
        
    }
}