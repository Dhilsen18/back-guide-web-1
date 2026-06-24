using System.ComponentModel.DataAnnotations;

namespace Pc27414u202319440.API.Services.Interfaces.REST.Resources;

/// <summary>
/// Address representation exposed by the REST API.
/// </summary>
public class AddressResource
{
    /// <summary>Gets or sets the street name.</summary>
    [Required(ErrorMessage = "Street is required.")]
    [MaxLength(40, ErrorMessage = "Street must not exceed 40 characters.")]
    public string Street { get; set; } = string.Empty;

    /// <summary>Gets or sets the city name.</summary>
    [Required(ErrorMessage = "City is required.")]
    [MaxLength(40, ErrorMessage = "City must not exceed 40 characters.")]
    public string City { get; set; } = string.Empty;

    /// <summary>Gets or sets the postal code.</summary>
    [Required(ErrorMessage = "Postal code is required.")]
    [MaxLength(40, ErrorMessage = "Postal code must not exceed 40 characters.")]
    public string PostalCode { get; set; } = string.Empty;
}
