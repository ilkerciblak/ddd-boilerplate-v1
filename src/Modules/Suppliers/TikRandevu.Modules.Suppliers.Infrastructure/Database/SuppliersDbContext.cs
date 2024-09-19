using Microsoft.EntityFrameworkCore;
using TikRandevu.Modules.Suppliers.Application.Abstractions.Data;
using TikRandevu.Modules.Suppliers.Domain.SupplierProvisions;
using TikRandevu.Modules.Suppliers.Domain.SupplierRezervations;
using TikRandevu.Modules.Suppliers.Domain.Suppliers;
using TikRandevu.Modules.Suppliers.Infrastructure.SupplierProvisions;
using TikRandevu.Modules.Suppliers.Infrastructure.SupplierRezervations;
using TikRandevu.Modules.Suppliers.Infrastructure.Suppliers;

namespace TikRandevu.Modules.Suppliers.Infrastructure.Database;

public class SuppliersDbContext : DbContext, IUnitOfWork
{
    public SuppliersDbContext(DbContextOptions<SuppliersDbContext> options) : base(options){}

    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<SupplierProvision> SupplierProvisions { get; set; }
    public DbSet<SupplierRezervation> SupplierRezervations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Suppliers");
        
        modelBuilder.ApplyConfiguration(new SuppliersDbConfig());
        modelBuilder.ApplyConfiguration(new SupplierProvisionDbConfig());
        modelBuilder.ApplyConfiguration(new SupplierRezervationsDbConfig());

        // base.OnModelCreating(modelBuilder);
    }
}