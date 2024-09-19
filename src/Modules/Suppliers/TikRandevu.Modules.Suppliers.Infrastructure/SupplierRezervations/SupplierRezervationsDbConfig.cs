using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TikRandevu.Modules.Suppliers.Domain.SupplierRezervations;

namespace TikRandevu.Modules.Suppliers.Infrastructure.SupplierRezervations;

public class SupplierRezervationsDbConfig : IEntityTypeConfiguration<SupplierRezervation>
{
    public void Configure(EntityTypeBuilder<SupplierRezervation> builder)
    {
        builder.HasKey(x => x.Identifier);

        builder.HasIndex(x => x.SupplierId)
            .IsUnique(false);
        
        builder.Property(x => x.IsArchived)
            .HasDefaultValue(false);
        builder.Property(x => x.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow);
    }
}