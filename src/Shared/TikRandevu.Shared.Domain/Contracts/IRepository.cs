namespace TikRandevu.Shared.Domain.Contracts;

public interface IRepository<TEntity>
{
    Task<TEntity?> GetAsync(Guid identifier, CancellationToken cancellationToken =default);

    Task Insert(TEntity value, CancellationToken cancellationToken =default);
}