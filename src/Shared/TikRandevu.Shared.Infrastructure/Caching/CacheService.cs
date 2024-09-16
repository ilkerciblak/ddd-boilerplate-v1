using Microsoft.Extensions.Caching.Distributed;
using TikRandevu.Shared.Application.Caching;

namespace TikRandevu.Shared.Infrastructure.Caching;

internal sealed class CacheService(IDistributedCache cache) : ICacheService
{
    public async Task<T?> GetCacheAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        var cached = await cache.GetAsync(key, cancellationToken);
        if (cached is not null)
        {
            return CacheSerializer.Deserialize<T>(cached);
        }

        return default;
    }

    public async Task SetCacheAsync<T>(
        string key, T value,
        TimeSpan? expirationDuration = null,
        CancellationToken cancellationToken = default)
    {
        var encoded = CacheSerializer.Serialize(value);
        await cache.SetAsync(
            key: key,
            value: encoded,
            options: expirationDuration is not null ? CacheOptions.Create(expirationDuration) : CacheOptions.DefaultCacheOptions,
            cancellationToken
        );
    }

    public async Task RemoveCacheAsync(string key, CancellationToken cancellationToken = default)
    {
        await cache.RemoveAsync(key, cancellationToken);
    }
}