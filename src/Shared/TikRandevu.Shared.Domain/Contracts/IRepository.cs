namespace TikRandevu.Shared.Domain.Contracts;

public interface IRepository<TEntity>
{
    Task<TEntity?> GetAsync(Guid identifier);

    Task Insert(TEntity value);
}