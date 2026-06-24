namespace Pc27414u202319440.API.Services.Domain.Model.ValueObjects;

/// <summary>
/// Represents a rental order monetary amount.
/// </summary>
public sealed record Amount(int Value)
{
    /// <summary>
    /// Creates a validated amount value object.
    /// </summary>
    /// <param name="value">Raw amount value.</param>
    /// <returns>Validated amount.</returns>
    public static Amount Create(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        return new Amount(value);
    }
}
