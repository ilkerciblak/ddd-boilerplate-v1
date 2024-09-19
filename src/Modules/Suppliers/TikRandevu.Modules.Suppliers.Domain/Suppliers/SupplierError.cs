using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Suppliers.Domain.Suppliers;

public static class SupplierError
{
    public static Error NotFound(Guid identifier) 
        => new NotFound<Supplier>(identifier);

    public static readonly Error AlreadyArchived 
        = new AlreadyArchived<Supplier>();
}