using Pc27414u202319440.API.Services.Domain.Model.Commands;
using Pc27414u202319440.API.Services.Domain.Model.ValueObjects;

namespace Pc27414u202319440.API.Services.Domain.Model.Aggregates;

/// <summary>
/// Rental order aggregate root.
/// </summary>
/// <remarks>Dhilsen Armil Mallqui Vilca</remarks>
public partial class RentalOrder
{
    /// <summary>
    /// Database unique constraint name for customer and vehicle pairs.
    /// </summary>
    public const string CustomerVehicleUniqueConstraint = "uk_rental_orders_customer_vehicles_id";

    /// <summary>
    /// EF Core parameterless constructor.
    /// </summary>
    protected RentalOrder()
    {
        Customer = null!;
        Address = null!;
    }

    /// <summary>
    /// Creates a rental order from a creation command.
    /// </summary>
    /// <param name="command">Creation command.</param>
    public RentalOrder(CreateRentalOrderCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        Customer = command.Customer.Value;
        VehiclesId = command.VehiclesId;
        Plate = command.Plate?.Value;
        RequestedAt = command.RequestedAt;
        Address = command.Address;
        Amount = command.Amount.Value;
    }

    /// <summary>Gets the rental order identifier.</summary>
    public int Id { get; private set; }

    /// <summary>Gets the customer name.</summary>
    public string Customer { get; private set; }

    /// <summary>Gets the selected vehicle identifier.</summary>
    public EVehicles VehiclesId { get; private set; }

    /// <summary>Gets the vehicle plate.</summary>
    public string? Plate { get; private set; }

    /// <summary>Gets the requested rental date and time.</summary>
    public DateTime RequestedAt { get; private set; }

    /// <summary>Gets the delivery address.</summary>
    public Address Address { get; private set; }

    /// <summary>Gets the rental amount.</summary>
    public int Amount { get; private set; }
}
