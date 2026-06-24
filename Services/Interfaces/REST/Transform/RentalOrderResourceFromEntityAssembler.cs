using Pc27414u202319440.API.Services.Domain.Model.Aggregates;
using Pc27414u202319440.API.Services.Interfaces.REST.Resources;

namespace Pc27414u202319440.API.Services.Interfaces.REST.Transform;

/// <summary>
/// Translates rental order aggregates into REST resources.
/// </summary>
public static class RentalOrderResourceFromEntityAssembler
{
    /// <summary>
    /// Maps a rental order aggregate to a response resource.
    /// </summary>
    /// <param name="rentalOrder">Rental order aggregate.</param>
    /// <returns>Response resource without amount or audit fields.</returns>
    public static RentalOrderResource ToResourceFromEntity(RentalOrder rentalOrder) =>
        new()
        {
            RentalOrderId = rentalOrder.Id,
            Customer = rentalOrder.Customer,
            VehiclesId = (int)rentalOrder.VehiclesId,
            Plate = rentalOrder.Plate,
            RequestedAt = rentalOrder.RequestedAt,
            Address = new AddressResource
            {
                Street = rentalOrder.Address.Street,
                City = rentalOrder.Address.City,
                PostalCode = rentalOrder.Address.PostalCode
            }
        };
}
