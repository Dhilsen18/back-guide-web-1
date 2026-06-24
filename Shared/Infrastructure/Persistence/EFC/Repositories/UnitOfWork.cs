using Pc27414u202319440.API.Shared.Domain.Repositories;
using Pc27414u202319440.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Pc27414u202319440.API.Shared.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Unit of work implementation for coordinating database transactions.
/// </summary>
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    /// <inheritdoc />
    public async Task CompleteAsync(CancellationToken cancellationToken = default) =>
        await context.SaveChangesAsync(cancellationToken);
}
