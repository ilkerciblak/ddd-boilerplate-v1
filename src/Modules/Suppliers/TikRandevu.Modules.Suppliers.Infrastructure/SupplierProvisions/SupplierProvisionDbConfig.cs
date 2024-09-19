using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TikRandevu.Modules.Suppliers.Domain.SupplierProvisions;

namespace TikRandevu.Modules.Suppliers.Infrastructure.SupplierProvisions;

public class SupplierProvisionDbConfig : IEntityTypeConfiguration<SupplierProvision>
{
    public void Configure(EntityTypeBuilder<SupplierProvision> builder)
    {
        builder
            .HasKey(x => x.Identifier);
        
        builder.Property(x => x.ProvisionId)
            .IsRequired();

        builder.Property(x => x.SupplierId)
            .IsRequired();

        builder.Property(x => x.IsArchived)
            .HasDefaultValue(false);

        builder.Property(x => x.Price)
            .IsRequired();
        
        builder.Property(x => x.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow);
    }
}