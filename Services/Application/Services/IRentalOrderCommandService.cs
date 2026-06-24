using Pc27414u202319440.API.Services.Application.Errors;
using Pc27414u202319440.API.Services.Domain.Model.Aggregates;
using Pc27414u202319440.API.Services.Domain.Model.Commands;
using Pc27414u202319440.API.Shared.Application.Patterns;

namespace Pc27414u202319440.API.Services.Application.Services;

/// <summary>
/// Command service contract for rental order operations.
/// </summary>
/// <remarks>Dhilsen Armil Mallqui Vilca</remarks>
public interface IRentalOrderCommandService
{
    /// <summary>
    /// Handles the create rental order command.
    /// </summary>
    /// <param name="command">Creation command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A result containing the created rental order or an error.</returns>
    Task<Result<RentalOrder, CreateRentalOrderError>> Handle(
        CreateRentalOrderCommand command,
        CancellationToken cancellationToken = default);
}
