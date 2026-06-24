namespace Pc27414u202319440.API.Services.Application.Errors;

/// <summary>
/// Errors that can occur when creating a rental order.
/// </summary>
public enum CreateRentalOrderError
{
    /// <summary>A rental order with the same customer and vehicle already exists.</summary>
    DuplicateCustomerAndVehicle,

    /// <summary>The provided plate is already associated with a different vehicle.</summary>
    PlateBelongsToDifferentVehicle,

    /// <summary>An unexpected error occurred during the operation.</summary>
    UnexpectedError
}
