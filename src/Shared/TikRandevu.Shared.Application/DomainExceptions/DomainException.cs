using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Shared.Application;

public sealed class DomainException : Exception
{
    public DomainException(string requestName, Error? error = default, Exception? innerException = default)
        : base("Application exception", innerException)
    {
        RequestName = requestName;
        Error = error;
    }

    public string RequestName { get; }

    public Error? Error { get; }
}