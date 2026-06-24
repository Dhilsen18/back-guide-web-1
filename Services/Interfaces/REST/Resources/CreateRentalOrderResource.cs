using System.ComponentModel.DataAnnotations;

namespace Pc27414u202319440.API.Services.Interfaces.REST.Resources;

/// <summary>
/// Request payload for creating a rental order.
/// </summary>
public class CreateRentalOrderResource
{
    /// <summary>Gets or sets the customer name.</summary>
    [Required(ErrorMessage = "Customer is required.")]
    [MaxLength(90, ErrorMessage = "Customer must not exceed 90 characters.")]
    public string Customer { get; set; } = string.Empty;

    /// <summary>Gets or sets the selected vehicle identifier.</summary>
    [Required(ErrorMessage = "VehiclesId is required.")]
    [Range(1, 6, ErrorMessage = "VehiclesId must be a valid Hertz vehicle.")]
    public int VehiclesId { get; set; }

    /// <summary>Gets or sets the vehicle plate.</summary>
    [MaxLength(12, ErrorMessage = "Plate must not exceed 12 characters.")]
    public string? Plate { get; set; }

    /// <summary>Gets or sets the requested rental date and time.</summary>
    [Required(ErrorMessage = "RequestedAt is required.")]
    public DateTime RequestedAt { get; set; }

    /// <summary>Gets or sets the delivery address.</summary>
    [Required(ErrorMessage = "Address is required.")]
    public AddressResource Address { get; set; } = new();

    /// <summary>Gets or sets the rental amount.</summary>
    [Required(ErrorMessage = "Amount is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
    public int Amount { get; set; }
}
