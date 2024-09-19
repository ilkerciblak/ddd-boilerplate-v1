using TikRandevu.Shared.Domain.Contracts;

namespace TikRandevu.Modules.Rezervations.Domain.Rezervations;

public interface IRezervationRepository : IRepository<Rezervation>
{
    Task<List<Rezervation>> GetAllAsync(
        Guid? customerId,
        Guid? supplierId,
        CancellationToken cancellationToken = default);

    Task<Guid> CompletePayment(
        Guid rezervationId,
        CancellationToken cancellationToken = default
    );
}