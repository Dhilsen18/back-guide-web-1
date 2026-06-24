namespace Pc27414u202319440.API.Services.Domain.Model.ValueObjects;

/// <summary>
/// Represents a vehicle license plate.
/// </summary>
public sealed record Plate(string Value)
{
    private const int MaxLength = 12;

    /// <summary>
    /// Creates a validated plate value object.
    /// </summary>
    /// <param name="value">Raw plate value.</param>
    /// <returns>Validated plate or null when omitted.</returns>
    public static Plate? Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        var trimmed = value.Trim();
        if (trimmed.Length > MaxLength)
        {
            throw new ArgumentException($"Plate must not exceed {MaxLength} characters.");
        }

        return new Plate(trimmed);
    }
}
