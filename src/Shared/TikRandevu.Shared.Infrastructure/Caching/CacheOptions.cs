using Microsoft.Extensions.Caching.Distributed;

namespace TikRandevu.Shared.Infrastructure.Caching;

internal static class CacheOptions
{
    internal static readonly DistributedCacheEntryOptions DefaultCacheOptions = new DistributedCacheEntryOptions
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
    };

    internal static DistributedCacheEntryOptions Create(TimeSpan? expirationDuration) => new DistributedCacheEntryOptions
    {
        AbsoluteExpirationRelativeToNow = expirationDuration
    };
}