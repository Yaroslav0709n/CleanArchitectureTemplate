using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Domain.Organizations;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Database;

public sealed class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, ApplicationRoleClaim, IdentityUserToken<Guid>>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Organization> Organizations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        int result = await base.SaveChangesAsync(cancellationToken);

        //await PublishDomainEventsAsync();

        return result;
    }

    //private async Task PublishDomainEventsAsync()
    //{
    //    var domainEvents = ChangeTracker
    //        .Entries<Entity>()
    //        .Select(entry => entry.Entity)
    //        .SelectMany(entity =>
    //        {
    //            List<IDomainEvent> domainEvents = entity.DomainEvents;

    //            entity.ClearDomainEvents();

    //            return domainEvents;
    //        })
    //        .ToList();

    //    await domainEventsDispatcher.DispatchAsync(domainEvents);
    //}
}
