using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using TikRandevu.Modules.Rezervations.Application.Abstractions.Data;
using TikRandevu.Modules.Rezervations.Domain.Rezervations;
using TikRandevu.Modules.Rezervations.Infrastructure.Rezervations;

namespace TikRandevu.Modules.Rezervations.Infrastructure.Database;

public sealed class RezervationsDbContext : DbContext, IUnitOfWork
{
    
    public RezervationsDbContext(DbContextOptions<RezervationsDbContext> options) : base(options){}
    
    public DbSet<Rezervation> Rezervations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RezervationsDbConfig());
        // base.OnModelCreating(modelBuilder);
    }
}