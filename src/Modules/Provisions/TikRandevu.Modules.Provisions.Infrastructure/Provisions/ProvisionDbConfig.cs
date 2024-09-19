using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TikRandevu.Modules.Provisions.Domain;

namespace TikRandevu.Modules.Provisions.Infrastructure.Provisions;

public sealed class ProvisionDbConfig :IEntityTypeConfiguration<Provision>
{
    public void Configure(EntityTypeBuilder<Provision> builder)
    {
        builder.HasKey(e => e.Identifier);

        builder.HasIndex(e => e.Name)
            .IsUnique();

        builder.Property(e => e.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.IsArchived)
            .HasDefaultValue(false);
        
    }
}