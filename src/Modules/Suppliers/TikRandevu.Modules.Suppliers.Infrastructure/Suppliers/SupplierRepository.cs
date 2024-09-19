using Microsoft.EntityFrameworkCore;
using TikRandevu.Modules.Suppliers.Domain.Suppliers;
using TikRandevu.Modules.Suppliers.Infrastructure.Database;

namespace TikRandevu.Modules.Suppliers.Infrastructure.Suppliers;

public sealed class SupplierRepository(SuppliersDbContext dbContext) : ISupplierRepository
{
    public async Task<Supplier?> GetAsync(Guid identifier, CancellationToken cancellationToken = default)
    {
        var supplier = await dbContext.Suppliers
            .Where(x => identifier == x.Identifier && !x.IsArchived)
            .SingleOrDefaultAsync(cancellationToken);


        return supplier;
    }

    public async Task Insert(Supplier value, CancellationToken cancellationToken = default)
    {
        await dbContext.Suppliers.AddAsync(value, cancellationToken);
    }

    public async Task<List<Supplier>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var supplier = await dbContext.Suppliers
            .Where(x =>  !x.IsArchived)
            .ToListAsync(cancellationToken);

        return supplier;
    }
}