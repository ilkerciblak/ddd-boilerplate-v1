namespace TikRandevu.Modules.Suppliers.PublicAPI.SupplierProvisions;

public sealed record SupplierProvisionResponse(Guid Identifier, Guid SupplierId, Guid ProvisionId, decimal Price);