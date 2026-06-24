namespace Pc27414u202319440.API.Services.Interfaces.REST.Resources;

/// <summary>
/// Rental order representation returned by the REST API.
/// </summary>
public class RentalOrderResource
{
    /// <summary>Gets or sets the rental order identifier.</summary>
    public int RentalOrderId { get; set; }

    /// <summary>Gets or sets the customer name.</summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>Gets or sets the selected vehicle identifier.</summary>
    public int VehiclesId { get; set; }

    /// <summary>Gets or sets the vehicle plate.</summary>
    public string? Plate { get; set; }

    /// <summary>Gets or sets the requested rental date and time.</summary>
    public DateTime RequestedAt { get; set; }

    /// <summary>Gets or sets the delivery address.</summary>
    public AddressResource Address { get; set; } = new();
}
