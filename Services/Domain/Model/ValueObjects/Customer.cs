namespace Pc27414u202319440.API.Services.Domain.Model.ValueObjects;

/// <summary>
/// Represents a rental order customer name.
/// </summary>
public sealed record Customer(string Value)
{
    private const int MaxLength = 90;

    /// <summary>
    /// Creates a validated customer value object.
    /// </summary>
    /// <param name="value">Raw customer name.</param>
    /// <returns>Validated customer.</returns>
    public static Customer Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Customer is required.");
        }

        if (value.Length > MaxLength)
        {
            throw new ArgumentException($"Customer must not exceed {MaxLength} characters.");
        }

        return new Customer(value.Trim());
    }
}
