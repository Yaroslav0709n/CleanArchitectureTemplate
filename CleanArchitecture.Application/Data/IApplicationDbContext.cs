using CleanArchitecture.Domain.Organizations;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Organization> Organizations { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
