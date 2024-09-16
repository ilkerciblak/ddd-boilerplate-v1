using MediatR;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Shared.Application.RequestBase;

internal interface IQuery<TResponse> : IRequest<Result<TResponse>>;
