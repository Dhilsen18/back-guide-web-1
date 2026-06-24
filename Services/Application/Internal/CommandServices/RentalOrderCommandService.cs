using Microsoft.EntityFrameworkCore;
using Pc27414u202319440.API.Services.Application.Errors;
using Pc27414u202319440.API.Services.Application.Services;
using Pc27414u202319440.API.Services.Domain.Model.Aggregates;
using Pc27414u202319440.API.Services.Domain.Model.Commands;
using Pc27414u202319440.API.Services.Domain.Repositories;
using Pc27414u202319440.API.Shared.Application.Patterns;
using Pc27414u202319440.API.Shared.Domain.Repositories;

namespace Pc27414u202319440.API.Services.Application.Internal.CommandServices;

/// <summary>
/// Application service for handling rental order creation commands.
/// </summary>
/// <remarks>Dhilsen Armil Mallqui Vilca</remarks>
public class RentalOrderCommandService(
    IRentalOrderRepository rentalOrderRepository,
    IUnitOfWork unitOfWork,
    ILogger<RentalOrderCommandService> logger) : IRentalOrderCommandService
{
    /// <inheritdoc />
    public async Task<Result<RentalOrder, CreateRentalOrderError>> Handle(
        CreateRentalOrderCommand command,
        CancellationToken cancellationToken = default)
    {
        var existingOrder = await rentalOrderRepository.FindByCustomerAndVehiclesIdAsync(
            command.Customer.Value,
            command.VehiclesId,
            cancellationToken);

        if (existingOrder is not null)
        {
            logger.LogWarning(
                "Duplicate rental order rejected for customer {Customer} and vehicle {VehiclesId}",
                command.Customer.Value,
                command.VehiclesId);

            return new Result<RentalOrder, CreateRentalOrderError>.Failure(
                CreateRentalOrderError.DuplicateCustomerAndVehicle);
        }

        if (command.Plate is not null)
        {
            var existingVehicleId = await rentalOrderRepository.FindVehiclesIdByPlateAsync(
                command.Plate.Value,
                cancellationToken);

            if (existingVehicleId.HasValue && existingVehicleId.Value != command.VehiclesId)
            {
                logger.LogWarning(
                    "Plate conflict rejected for plate {Plate} and vehicle {VehiclesId}",
                    command.Plate.Value,
                    command.VehiclesId);

                return new Result<RentalOrder, CreateRentalOrderError>.Failure(
                    CreateRentalOrderError.PlateBelongsToDifferentVehicle);
            }
        }

        try
        {
            var rentalOrder = new RentalOrder(command);
            await rentalOrderRepository.AddAsync(rentalOrder, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);

            return new Result<RentalOrder, CreateRentalOrderError>.Success(rentalOrder);
        }
        catch (DbUpdateException exception) when (IsDuplicateKeyViolation(exception))
        {
            logger.LogWarning(exception,
                "Duplicate key violation creating rental order for customer {Customer} and vehicle {VehiclesId}",
                command.Customer.Value,
                command.VehiclesId);

            return new Result<RentalOrder, CreateRentalOrderError>.Failure(
                CreateRentalOrderError.DuplicateCustomerAndVehicle);
        }
        catch (Exception exception)
        {
            logger.LogError(exception,
                "Unexpected error creating rental order for customer {Customer} and vehicle {VehiclesId}",
                command.Customer.Value,
                command.VehiclesId);

            return new Result<RentalOrder, CreateRentalOrderError>.Failure(
                CreateRentalOrderError.UnexpectedError);
        }
    }

    private static bool IsDuplicateKeyViolation(DbUpdateException exception)
    {
        for (Exception? current = exception; current is not null; current = current.InnerException)
        {
            if (!string.Equals(current.GetType().Name, "MySqlException", StringComparison.Ordinal))
            {
                continue;
            }

            var numberProperty = current.GetType().GetProperty("Number");
            if (numberProperty?.PropertyType == typeof(int) &&
                numberProperty.GetValue(current) is int errorCode &&
                errorCode == 1062)
            {
                return true;
            }
        }

        return false;
    }
}
