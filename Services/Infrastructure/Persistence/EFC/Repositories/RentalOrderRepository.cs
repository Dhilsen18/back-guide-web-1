using Microsoft.EntityFrameworkCore;
using Pc27414u202319440.API.Services.Domain.Model.Aggregates;
using Pc27414u202319440.API.Services.Domain.Model.ValueObjects;
using Pc27414u202319440.API.Services.Domain.Repositories;
using Pc27414u202319440.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Pc27414u202319440.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Pc27414u202319440.API.Services.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Entity Framework repository for rental order persistence.
/// </summary>
public class RentalOrderRepository(AppDbContext context)
    : BaseRepository<RentalOrder>(context), IRentalOrderRepository
{
    /// <inheritdoc />
    public async Task<RentalOrder?> FindByCustomerAndVehiclesIdAsync(
        string customer,
        EVehicles vehiclesId,
        CancellationToken cancellationToken = default) =>
        await Context.Set<RentalOrder>()
            .FirstOrDefaultAsync(
                rentalOrder => rentalOrder.Customer == customer && rentalOrder.VehiclesId == vehiclesId,
                cancellationToken);

    /// <inheritdoc />
    public async Task<EVehicles?> FindVehiclesIdByPlateAsync(
        string plate,
        CancellationToken cancellationToken = default)
    {
        var rentalOrder = await Context.Set<RentalOrder>()
            .AsNoTracking()
            .FirstOrDefaultAsync(current => current.Plate == plate, cancellationToken);

        return rentalOrder?.VehiclesId;
    }
}
