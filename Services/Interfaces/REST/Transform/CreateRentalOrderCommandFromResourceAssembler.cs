using Pc27414u202319440.API.Services.Domain.Model.Commands;
using Pc27414u202319440.API.Services.Domain.Model.ValueObjects;
using Pc27414u202319440.API.Services.Interfaces.REST.Resources;

namespace Pc27414u202319440.API.Services.Interfaces.REST.Transform;

/// <summary>
/// Translates REST resources into domain commands.
/// </summary>
public static class CreateRentalOrderCommandFromResourceAssembler
{
    /// <summary>
    /// Maps a creation resource to a domain command.
    /// </summary>
    /// <param name="resource">Creation resource.</param>
    /// <returns>Domain command.</returns>
    public static CreateRentalOrderCommand ToCommandFromResource(CreateRentalOrderResource resource) =>
        new(
            Customer.Create(resource.Customer),
            (EVehicles)resource.VehiclesId,
            Plate.Create(resource.Plate),
            resource.RequestedAt,
            Address.Create(resource.Address.Street, resource.Address.City, resource.Address.PostalCode),
            Amount.Create(resource.Amount));
}
