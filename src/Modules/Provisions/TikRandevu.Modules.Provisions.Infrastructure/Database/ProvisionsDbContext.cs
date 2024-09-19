using Microsoft.EntityFrameworkCore;
using TikRandevu.Modules.Provisions.Application.Data;
using TikRandevu.Modules.Provisions.Domain;
using TikRandevu.Modules.Provisions.Infrastructure.Provisions;

namespace TikRandevu.Modules.Provisions.Infrastructure.Database;

public class ProvisionsDbContext : DbContext, IUnitOfWork
{
    public ProvisionsDbContext(DbContextOptions<ProvisionsDbContext> options) : base(options)
    {
    }

    public DbSet<Provision> Provisions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProvisionDbConfig());
        // base.OnModelCreating(modelBuilder);
    }
}