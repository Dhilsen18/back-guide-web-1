using Pc27414u202319440.API.Shared.Domain.Model;

namespace Pc27414u202319440.API.Services.Domain.Model.Aggregates;

/// <summary>
/// Audit extension for the rental order aggregate.
/// </summary>
public partial class RentalOrder : IAuditableEntity
{
    /// <summary>Gets the creation timestamp.</summary>
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>Gets the last update timestamp.</summary>
    public DateTimeOffset? UpdatedAt { get; set; }
}
