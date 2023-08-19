using MediatR;

namespace RideShare.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<TResponse>
{

}
