using MediatR;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Shared.Application.RequestBase;

internal interface ICommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse>>
    where TRequest : ICommand<TResponse>;

internal interface ICommandHandler<TRequest> : IRequestHandler<TRequest, Result>
    where TRequest : ICommand;
