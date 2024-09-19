using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TikRandevu.Modules.Rezervations.Domain.Rezervations;

namespace TikRandevu.Modules.Rezervations.Infrastructure.Rezervations;

public class RezervationsDbConfig : IEntityTypeConfiguration<Rezervation>
{
    public void Configure(EntityTypeBuilder<Rezervation> builder)
    {
        builder.HasKey(x => x.Identifier);

        builder.Property(x => x.IsPaid)
            .HasDefaultValue(false);

        builder.Property(x => x.IsArchived)
            .HasDefaultValue(false);
        
        
    }
}