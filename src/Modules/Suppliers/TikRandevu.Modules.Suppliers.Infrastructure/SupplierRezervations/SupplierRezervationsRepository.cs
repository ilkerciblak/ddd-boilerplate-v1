using Microsoft.EntityFrameworkCore;
using TikRandevu.Modules.Suppliers.Domain.SupplierRezervations;
using TikRandevu.Modules.Suppliers.Infrastructure.Database;

namespace TikRandevu.Modules.Suppliers.Infrastructure.SupplierRezervations;

public class SupplierRezervationsRepository(SuppliersDbContext dbContext)
    : ISupplierRezervationRepository
{
    public async Task<SupplierRezervation?> GetAsync(Guid identifier, CancellationToken cancellationToken = default)
    {
        var rezervation = await dbContext.SupplierRezervations
            .Where(x=>x.Identifier == identifier && !x.IsArchived)
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);

        return rezervation;

    }

    public async Task Insert(SupplierRezervation value, CancellationToken cancellationToken = default)
    {
        await dbContext.SupplierRezervations.AddAsync(value, cancellationToken);
    }

    public async Task<List<SupplierRezervation>> GetAllAsync(Guid? supplierId = null, CancellationToken cancellationToken = default)
    {
        var list = await dbContext.SupplierRezervations
            .Where(x =>
                !x.IsArchived &&
                (supplierId == null || supplierId == x.SupplierId)
            )
            .AsNoTracking()
            .ToListAsync();

        return list;
    }
}