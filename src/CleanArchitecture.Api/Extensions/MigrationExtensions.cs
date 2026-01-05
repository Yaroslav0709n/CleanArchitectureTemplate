using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Api.Extensions;

public static class MigrationExtensions
{
    public static async Task ApplyMigrationsAsync(this IApplicationBuilder app, CancellationToken cancellationToken)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if (!dbContext.Database.GetMigrations().Any())
        {
            return;
        }

        if ((await dbContext.Database.GetPendingMigrationsAsync(cancellationToken)).Any())
        {
            await dbContext.Database.MigrateAsync(cancellationToken);
        }

        if (await dbContext.Database.CanConnectAsync(cancellationToken))
        {
            var dbSeeder = scope.ServiceProvider.GetRequiredService<IApplicationDbSeeder>();

            await dbSeeder.SeedDatabaseAsync();
        }
    }
}
