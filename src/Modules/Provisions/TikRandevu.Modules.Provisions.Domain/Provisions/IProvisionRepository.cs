using TikRandevu.Shared.Domain.Contracts;

namespace TikRandevu.Modules.Provisions.Domain;

public interface IProvisionRepository : IRepository<Provision>
{
    Task<List<Provision>> GetAllAsync(int? pageNumber = 1, int? pageSize = 100, CancellationToken cancellationToken = default);
}