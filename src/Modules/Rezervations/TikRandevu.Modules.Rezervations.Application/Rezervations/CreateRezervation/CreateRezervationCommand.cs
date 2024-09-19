using TikRandevu.Shared.Application.RequestBase;

namespace TikRandevu.Modules.Rezervations.Application.Rezervations.CreateRezervation;

public sealed record CreateRezervationCommand(
    Guid SupplierId,
    Guid CustomerId,
    Guid SupplierProvisionId,
    DateTime RezervationDate) : ICommand<Guid>;