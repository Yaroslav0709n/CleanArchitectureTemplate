using CleanArchitecture.Application.Abstractions.CurrentUser;

namespace CleanArchitecture.Api.Middlewares;

public class CurrentUserMiddleware : IMiddleware
{
    private readonly ICurrentUserInitializer currentUserInitializer;

    public CurrentUserMiddleware(ICurrentUserInitializer currentUserInitializer)
    {
        this.currentUserInitializer = currentUserInitializer;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        currentUserInitializer.SetCurrentUser(context.User);

        await next(context);
    }
}