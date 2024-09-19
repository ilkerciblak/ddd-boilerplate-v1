using System.Text.Json.Serialization;
using TikRandevu.Shared.Domain.Abstractions;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Suppliers.Domain.Suppliers;

public sealed class Supplier : Aggregate
{
    public string Name { get; private set; }
    public string FullAddress { get; private set; }
    
    private Supplier()
    {}

    [JsonConstructor]
    public Supplier(string name, string fullAddress, Guid identifier, bool isArchived, DateTime createdAt,
        DateTime updatedAt, DateTime deletedAt)
        : base(identifier, isArchived, createdAt, updatedAt, deletedAt)
    {
        Name = name;
        FullAddress = fullAddress;
    }


    public static Result<Supplier> Create(string name, string fullAddress)
    {
        var supplier = new Supplier
        {
            Identifier = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            Name = name,
            FullAddress = fullAddress
        };

        return supplier;
    }

    public Result<Guid> Archive()
    {
        if (IsArchived)
        {
            return Result<Guid>.Failure<Guid>(new AlreadyArchived<Supplier>());
        }

        IsArchived = true;
        DeletedAt = DateTime.UtcNow;

        return Identifier;
    }
    
    
    
}