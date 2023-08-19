namespace RideShare.Domain.Exceptions;

public sealed class DomainException : Exception
{
    public DomainException(string message) : base(message)
    {

    }
}