namespace RideShare.Domain.Abstractions;

/// <summary>
/// Defines <c>IAggregateRoot</c> interface to mark Aggregate Root entities.
/// Repositories only work with aggregate roots, not their children.
/// </summary>
public interface IAggregateRoot
{ }