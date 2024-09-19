using MediatR;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Shared.Application.RequestBase;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

public interface IBaseCommand;
