using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TikRandevu.Modules.Suppliers.Domain.SupplierProvisions;
using TikRandevu.Modules.Suppliers.Domain.SupplierRezervations;
using TikRandevu.Modules.Suppliers.Domain.Suppliers;

namespace TikRandevu.Modules.Suppliers.Infrastructure.Suppliers;

public class SuppliersDbConfig : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasKey(x => x.Identifier);

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.Property(x => x.IsArchived)
            .HasDefaultValue(false);

        builder.Property(x => x.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow);

        builder.HasMany<SupplierProvision>()
            .WithOne()
            .HasForeignKey(p=>p.SupplierId);

        builder.HasMany<SupplierRezervation>()
            .WithOne()
            .HasForeignKey(r => r.SupplierId);
    }
}