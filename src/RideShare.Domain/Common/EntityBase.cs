namespace RideShare.Domain.Common;

/// <summary>
/// Defines base entity class for RideShare entities.
/// </summary>
public abstract class EntityBase
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
}