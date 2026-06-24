using Pc27414u202319440.API.Shared.Domain.Repositories;
using Pc27414u202319440.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Pc27414u202319440.API.Shared.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Generic base repository providing CRUD operations.
/// </summary>
/// <typeparam name="TEntity">The entity type.</typeparam>
public class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity>
    where TEntity : class
{
    /// <summary>
    /// Gets the EF Core database context.
    /// </summary>
    protected readonly AppDbContext Context = context;

    /// <inheritdoc />
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        await Context.Set<TEntity>().AddAsync(entity, cancellationToken);

    /// <inheritdoc />
    public async Task<TEntity?> FindByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await Context.Set<TEntity>().FindAsync([id], cancellationToken);

    /// <inheritdoc />
    public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);

    /// <inheritdoc />
    public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);

    /// <inheritdoc />
    public async Task<IEnumerable<TEntity>> ListAsync(CancellationToken cancellationToken = default) =>
        await Context.Set<TEntity>().ToListAsync(cancellationToken);
}
