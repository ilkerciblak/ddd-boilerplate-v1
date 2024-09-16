using System.Buffers;
using System.Text.Json;

namespace TikRandevu.Shared.Infrastructure.Caching;

internal static class CacheSerializer
{
    internal static T Deserialize<T>(byte[]? bytes)
    {
        return JsonSerializer.Deserialize<T>(bytes);
    }

    internal static byte[] Serialize<T>(T value)
    {
        var buffer = new ArrayBufferWriter<byte>();
        using var writer = new Utf8JsonWriter(buffer);
        JsonSerializer.Serialize(writer, value);
        return buffer.WrittenSpan.ToArray();
    }
}