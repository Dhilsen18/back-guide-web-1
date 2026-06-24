using Pc27414u202319440.API.Services.Domain.Model.ValueObjects;

namespace Pc27414u202319440.API.Services.Domain.Model.Commands;

/// <summary>
/// Command message for creating a new rental order.
/// </summary>
/// <remarks>Dhilsen Armil Mallqui Vilca</remarks>
public sealed record CreateRentalOrderCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateRentalOrderCommand"/> record.
    /// </summary>
    public CreateRentalOrderCommand(
        Customer customer,
        EVehicles vehiclesId,
        Plate? plate,
        DateTime requestedAt,
        Address address,
        Amount amount)
    {
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        VehiclesId = ValidateVehicle(vehiclesId);
        Plate = plate;
        RequestedAt = ValidateRequestedAt(requestedAt);
        Address = address ?? throw new ArgumentNullException(nameof(address));
        Amount = amount ?? throw new ArgumentNullException(nameof(amount));
    }

    /// <summary>Gets the customer name.</summary>
    public Customer Customer { get; }

    /// <summary>Gets the selected vehicle identifier.</summary>
    public EVehicles VehiclesId { get; }

    /// <summary>Gets the vehicle plate.</summary>
    public Plate? Plate { get; }

    /// <summary>Gets the requested rental date and time.</summary>
    public DateTime RequestedAt { get; }

    /// <summary>Gets the delivery address.</summary>
    public Address Address { get; }

    /// <summary>Gets the rental amount.</summary>
    public Amount Amount { get; }

    private static EVehicles ValidateVehicle(EVehicles vehiclesId)
    {
        if (!Enum.IsDefined(vehiclesId))
        {
            throw new ArgumentException("VehiclesId must be a valid Hertz vehicle.");
        }

        return vehiclesId;
    }

    private static DateTime ValidateRequestedAt(DateTime requestedAt)
    {
        if (requestedAt.Date < DateTime.Now.Date)
        {
            throw new ArgumentException("Requested date cannot be earlier than the current system date.");
        }

        return requestedAt;
    }
}
