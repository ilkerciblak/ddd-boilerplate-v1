using MediatR;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Shared.Application.RequestBase;

internal interface ICommand : IRequest<Result>, IBaseCommand;

internal interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

internal interface IBaseCommand;
