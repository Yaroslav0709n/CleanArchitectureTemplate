using CleanArchitecture.Domain.Organizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Organizations;

internal sealed class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(200);

        builder.Property(x => x.Phone).HasMaxLength(200);

        builder.Property(x => x.Fax).HasMaxLength(200);

        builder.Property(x => x.Email).HasMaxLength(200);

        builder.OwnsOne(o => o.Address, x =>
        {
            x.Property(a => a.City).HasMaxLength(50);
            x.Property(a => a.Street).HasMaxLength(50);
            x.Property(a => a.HomeNumber).HasMaxLength(10);
            x.Property(a => a.ApartmentNumber).HasMaxLength(10);
            x.Property(a => a.ZipCode).HasMaxLength(10);
            x.Property(a => a.MailBox).HasMaxLength(10);
        });
    }
}