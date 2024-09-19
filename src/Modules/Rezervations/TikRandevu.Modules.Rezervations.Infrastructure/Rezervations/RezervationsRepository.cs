using Microsoft.EntityFrameworkCore;
using TikRandevu.Modules.Rezervations.Domain.Rezervations;
using TikRandevu.Modules.Rezervations.Infrastructure.Database;

namespace TikRandevu.Modules.Rezervations.Infrastructure.Rezervations;

public sealed class RezervationsRepository(RezervationsDbContext dbContext)
    : IRezervationRepository
{
    public async Task<Rezervation?> GetAsync(Guid identifier, CancellationToken cancellationToken = default)
    {
        var rez = await dbContext.Rezervations
            .Where(x => x.Identifier == identifier)
            .SingleOrDefaultAsync(cancellationToken);

        return rez;
    }

    public async Task Insert(Rezervation value, CancellationToken cancellationToken = default)
    {
        await dbContext.Rezervations.AddAsync(value, cancellationToken);
    }

    public async Task<List<Rezervation>> GetAllAsync(Guid? customerId, Guid? supplierId, CancellationToken cancellationToken = default)
    {
        var rez = await dbContext.Rezervations
            .Where(x =>
                (customerId == null || x.CustomerId == customerId) &&
                (supplierId == null || x.SupplierId == supplierId)
            )
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return rez;
    }

   
}