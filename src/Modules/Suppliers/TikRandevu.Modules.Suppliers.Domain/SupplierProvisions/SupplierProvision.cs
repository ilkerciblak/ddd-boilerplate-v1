using TikRandevu.Shared.Domain.Abstractions;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Suppliers.Domain.SupplierProvisions;

public sealed class SupplierProvision : Entity
{
    public Guid ProvisionId { get; private set; }
    public Guid SupplierId { get; private set; }
    public decimal Price { get; private set; }


    private SupplierProvision()
    {
    }


    public static Result<SupplierProvision> Create(Guid provisionId, Guid supplierId, decimal price)
    {
        if (price < 0)
        {
            return Result<SupplierProvision>.Failure<SupplierProvision>(
                Error.Problem("SupplierProvision.Price",
                    "Price Entry is not Valid")
            );
        }

        var supplierProvision = new SupplierProvision
        {
            Identifier = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            ProvisionId = provisionId,
            SupplierId = supplierId,
            Price = price
        };

        return supplierProvision;
    }
    
}