namespace Pc27414u202319440.API.Shared.Domain.Repositories;

/// <summary>
/// Unit of work interface.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Commits changes to the database.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task CompleteAsync(CancellationToken cancellationToken = default);
}
