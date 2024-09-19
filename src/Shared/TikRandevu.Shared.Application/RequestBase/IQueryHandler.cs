using MediatR;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Shared.Application.RequestBase;

public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse>>
    where TRequest : IQuery<TResponse>;