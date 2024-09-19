using System.Text.Json.Serialization;
using TikRandevu.Modules.Provisions.Domain.Categories;
using TikRandevu.Shared.Domain.Abstractions;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Provisions.Domain;

public class Provision : Aggregate
{
    public string Name { get; private set; }
    // public Guid CategoryId { get; private set; }

    private Provision()
    {
    }


    [JsonConstructor]
    public Provision(
        string name,
        Guid categoryId,
        Guid identifier,
        bool isArchived,
        DateTime createdAt,
        DateTime updatedAt,
        DateTime deletedAt
    )
        : base(identifier, isArchived, createdAt, updatedAt, deletedAt)
    {
        Name = name;
        // CategoryId = categoryId;
    }


    public Result Archive()
    {
        if (IsArchived)
        {
            return Result.Failure(ProvisionError.AlreadyArchived);
        }

        IsArchived = true;
        DeletedAt = DateTime.UtcNow;

        return Result.Success();
    }

    public static Result<Provision> Create(string name)
    {
        return new Provision
        {
            IsArchived = false,
            CreatedAt = DateTime.UtcNow,
            Identifier = Guid.NewGuid(),
            Name = name

        };
    }
}