using Microsoft.EntityFrameworkCore;
using TikRandevu.Modules.Suppliers.Domain.SupplierProvisions;
using TikRandevu.Modules.Suppliers.Infrastructure.Database;
using TikRandevu.Modules.Suppliers.Infrastructure.Suppliers;

namespace TikRandevu.Modules.Suppliers.Infrastructure.SupplierProvisions;

public class SupplierProvisionRepository(SuppliersDbContext dbContext) : ISupplierProvisionRepository
{
    public async Task<SupplierProvision?> GetAsync(Guid identifier, CancellationToken cancellationToken = default)
    {
        var provision = await dbContext.SupplierProvisions
            .Where(x => x.Identifier == identifier && !x.IsArchived)
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);

        return provision;
    }

    public async Task Insert(SupplierProvision value, CancellationToken cancellationToken = default)
    {
        await dbContext.SupplierProvisions.AddAsync(value, cancellationToken);
    }

    public async Task<List<SupplierProvision>> GetAllAsync(Guid? supplierId,
        CancellationToken cancellationToken = default)
    {
        var provision = await dbContext.SupplierProvisions
            .Where(x => !x.IsArchived &&
                        (supplierId == null || x.SupplierId == supplierId)
            )
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return provision;
    }
}