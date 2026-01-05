namespace CleanArchitecture.Application.Abstractions.Data;

public interface IApplicationDbSeeder
{
    Task SeedDatabaseAsync();
}
