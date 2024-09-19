using TikRandevu.Shared.Domain.Abstractions;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Suppliers.Domain.SupplierRezervations;

public sealed class SupplierRezervation : Entity
{
    public Guid SupplierId { get; private set; }
    
    public string CustomerName { get; private set; }
    
    public Guid ProvisionId { get; private set; } // SupplierProvision
    public Guid CustomerId { get; private set; }
    public DateTime RezervationDate { get; private set; }


    private SupplierRezervation()
    {
    }

    public static Result<SupplierRezervation> Create(
        Guid supplierId,
        Guid provisionId,
        Guid customerId,
        DateTime rezervartionTime)
    {
        if (DateTime.Compare(rezervartionTime, DateTime.UtcNow) <= 0)
        {
            return Result<SupplierRezervation>.Failure<SupplierRezervation>(
                Error.Problem("Rezervation.Date",
                    "Selected Rezervation Date is invalid")
            );
        }

        var rezervation = new SupplierRezervation
        {
            Identifier = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            SupplierId = supplierId,
            ProvisionId = provisionId,
            CustomerId = customerId,
            RezervationDate = rezervartionTime
        };

        return rezervation;
    }
    
    
}