using MediatR;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Shared.Application.RequestBase;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
