namespace TikRandevu.Shared.Application.Caching;

public interface ICacheService
{
    Task<T?> GetCacheAsync<T>(string key, CancellationToken cancellationToken = default);

    Task SetCacheAsync<T>(
        string key,
        T value,
        TimeSpan? expirationDuration = null,
        CancellationToken cancellationToken = default
    );

    Task RemoveCacheAsync(
        string key,
        CancellationToken cancellationToken = default
    );
}