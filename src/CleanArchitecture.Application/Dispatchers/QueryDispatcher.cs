using CleanArchitecture.Application.Abstractions.Dispatchers;
using CleanArchitecture.Application.Abstractions.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application.Dispatchers;

public class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task<TResponse> Dispatch<TQuery, TResponse>(TQuery query, CancellationToken cancellation) 
        where TQuery : IQuery<TResponse>
    {
        var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResponse>>();

        return handler.Handle(query, cancellation);
    }
}
