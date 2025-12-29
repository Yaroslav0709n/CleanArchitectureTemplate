using CleanArchitecture.Api.Middlewares;

namespace CleanArchitecture.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        services.AddScoped<ExceptionMiddleware>();

        services.AddScoped<CurrentUserMiddleware>();

        return services;
    }

    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app) => app.UseMiddleware<ExceptionMiddleware>();

    public static IApplicationBuilder UseCurrentUserMiddleware(this IApplicationBuilder app) => app.UseMiddleware<CurrentUserMiddleware>();
}
