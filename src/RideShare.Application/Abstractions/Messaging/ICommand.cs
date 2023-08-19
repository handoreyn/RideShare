using MediatR;

namespace RideShare.Application.Abstractions.Messaging;

public interface ICommand : IRequest
{

}

public interface ICommand<TResponse> : IRequest<TResponse>
{
    
}