using System.Text.Json.Serialization;
using TikRandevu.Shared.Domain.Abstractions;

namespace TikRandevu.Modules.Provisions.Domain.Categories;

public class ProvisionCategory : Entity
{
    public string Name { get; private set; }

    [JsonConstructor]
    public ProvisionCategory(
        string name,
        Guid identifier,
        bool isArchived,
        DateTime createdAt,
        DateTime updatedAt,
        DateTime deletedAt
    )
        : base(identifier, isArchived, createdAt, updatedAt, deletedAt)
    {
        Name = name;
    }
}