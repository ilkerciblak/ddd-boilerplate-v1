using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Provisions.Domain.Categories;

public abstract class ProvisionCategoryError
{
    public static Error NotFound(Guid identifier) =>
        new NotFound<Provision>(identifier);

    public static readonly Error AlreadyArchived = new AlreadyArchived<Provision>();
}