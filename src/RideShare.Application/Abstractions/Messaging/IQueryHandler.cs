using MediatR;

namespace RideShare.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery: IQuery<TResponse>
{}