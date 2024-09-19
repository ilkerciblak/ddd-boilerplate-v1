using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Provisions.Domain;

public abstract class ProvisionError
{
    public static Error NotFound(Guid identifier) =>
        new NotFound<Provision>(identifier);

    public static readonly Error AlreadyArchived = new AlreadyArchived<Provision>();
}

