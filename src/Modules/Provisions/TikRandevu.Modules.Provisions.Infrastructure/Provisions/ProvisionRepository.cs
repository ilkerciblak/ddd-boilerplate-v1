using Microsoft.EntityFrameworkCore;
using TikRandevu.Modules.Provisions.Domain;
using TikRandevu.Modules.Provisions.Infrastructure.Database;

namespace TikRandevu.Modules.Provisions.Infrastructure.Provisions;

public sealed class ProvisionRepository(ProvisionsDbContext dbContext)
    : IProvisionRepository
{
    public async Task<Provision?> GetAsync(Guid identifier, CancellationToken cancellationToken = default)
    {
        var provision = await dbContext.Provisions
            .Where(e => e.Identifier == identifier && !e.IsArchived)
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);


        return provision;

        // throw new NotImplementedException();
    }

    public async Task Insert(Provision value, CancellationToken cancellationToken = default)
    {
        await dbContext.Provisions.AddAsync(value, cancellationToken);
    }

    public async Task<List<Provision>> GetAllAsync(int? pageNumber, int? pageSize,
        CancellationToken cancellationToken = default)
    {
        var list = await dbContext.Provisions
            .Where(e => !e.IsArchived)
            .ToListAsync(cancellationToken);

        return list;
    }
}