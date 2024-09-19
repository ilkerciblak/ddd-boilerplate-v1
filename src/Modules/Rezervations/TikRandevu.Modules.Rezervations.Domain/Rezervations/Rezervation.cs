using TikRandevu.Modules.Rezervations.Domain.Rezervations.DomainEvents;
using TikRandevu.Shared.Domain.Abstractions;
using TikRandevu.Shared.Domain.ResponseFoundation;

namespace TikRandevu.Modules.Rezervations.Domain.Rezervations;

public class Rezervation : Aggregate
{
    public Guid SupplierId { get; private set; }
    public Guid SupplierProvisionId { get; private set; }
    public Guid CustomerId { get; private set; }

    public DateTime RezervationDate { get; private set; }
    public bool IsPaid { get; private set; }


    private Rezervation()
    {
    }

    public static Result<Rezervation> Create(Guid supplierId, Guid supplierProvisionId, Guid customerId,
        DateTime rezervationDate)
    {
        if (DateTime.Compare(rezervationDate, DateTime.UtcNow) <= 0)
        {
            return Result<Rezervation>.Failure<Rezervation>(Error.Problem("Rezervations.Date", "Boyle olmaz aga"));
        }

        var rezervation = new Rezervation
        {
            Identifier = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            SupplierId = supplierId,
            CustomerId = customerId,
            SupplierProvisionId = supplierProvisionId,
            RezervationDate = rezervationDate,
            IsPaid = false,
            IsArchived = false,
        };


        return rezervation;
    }

    public Result PayForRezervation()
    {
        if (IsPaid)
        {
            return Result.Failure(RezervationError.AlreadyPaid);
        }

        IsPaid = true;

        this.Raise(new RezervationPaidDomainEvent(this.Identifier));

        return Result.Success();
    }
}