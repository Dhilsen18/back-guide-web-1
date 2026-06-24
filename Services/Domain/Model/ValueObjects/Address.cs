namespace Pc27414u202319440.API.Services.Domain.Model.ValueObjects;

/// <summary>
/// Represents a rental delivery address owned by a rental order.
/// </summary>
public class Address
{
    private const int MaxComponentLength = 40;

    /// <summary>
    /// Gets the street name.
    /// </summary>
    public string Street { get; private set; } = null!;

    /// <summary>
    /// Gets the city name.
    /// </summary>
    public string City { get; private set; } = null!;

    /// <summary>
    /// Gets the postal code.
    /// </summary>
    public string PostalCode { get; private set; } = null!;

    private Address()
    {
    }

    /// <summary>
    /// Creates a validated address value object.
    /// </summary>
    /// <param name="street">Street value.</param>
    /// <param name="city">City value.</param>
    /// <param name="postalCode">Postal code value.</param>
    /// <returns>Validated address.</returns>
    public static Address Create(string street, string city, string postalCode)
    {
        if (string.IsNullOrWhiteSpace(street))
        {
            throw new ArgumentException("Street is required.");
        }

        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ArgumentException("City is required.");
        }

        if (string.IsNullOrWhiteSpace(postalCode))
        {
            throw new ArgumentException("Postal code is required.");
        }

        var trimmedStreet = street.Trim();
        var trimmedCity = city.Trim();
        var trimmedPostalCode = postalCode.Trim();

        if (trimmedStreet.Length > MaxComponentLength)
        {
            throw new ArgumentException($"Street must not exceed {MaxComponentLength} characters.");
        }

        if (trimmedCity.Length > MaxComponentLength)
        {
            throw new ArgumentException($"City must not exceed {MaxComponentLength} characters.");
        }

        if (trimmedPostalCode.Length > MaxComponentLength)
        {
            throw new ArgumentException($"Postal code must not exceed {MaxComponentLength} characters.");
        }

        return new Address
        {
            Street = trimmedStreet,
            City = trimmedCity,
            PostalCode = trimmedPostalCode
        };
    }
}
