using Pc27414u202319440.API.Services.Domain.Model.Aggregates;
using Pc27414u202319440.API.Services.Domain.Model.ValueObjects;
using Pc27414u202319440.API.Shared.Domain.Repositories;

namespace Pc27414u202319440.API.Services.Domain.Repositories;

/// <summary>
/// Rental order repository contract.
/// </summary>
public interface IRentalOrderRepository : IBaseRepository<RentalOrder>
{
    /// <summary>
    /// Finds a rental order by customer and vehicle identifier.
    /// </summary>
    /// <param name="customer">Customer name.</param>
    /// <param name="vehiclesId">Vehicle identifier.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The rental order if found; otherwise null.</returns>
    Task<RentalOrder?> FindByCustomerAndVehiclesIdAsync(
        string customer,
        EVehicles vehiclesId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Finds the vehicle identifier associated with a plate.
    /// </summary>
    /// <param name="plate">Vehicle plate.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The vehicle identifier if found; otherwise null.</returns>
    Task<EVehicles?> FindVehiclesIdByPlateAsync(
        string plate,
        CancellationToken cancellationToken = default);
}
