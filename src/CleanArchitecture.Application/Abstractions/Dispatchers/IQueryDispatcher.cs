using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Abstractions.Dispatchers;

public interface IQueryDispatcher
{
    Task<TResponse> Dispatch<TQuery, TResponse>(TQuery query, CancellationToken cancellation)
        where TQuery : IQuery<TResponse>;
}
