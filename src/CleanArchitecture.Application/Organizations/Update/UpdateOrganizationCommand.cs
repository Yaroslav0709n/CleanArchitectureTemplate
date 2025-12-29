using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Addresses.Dto;

namespace CleanArchitecture.Application.Organizations.Update;

public sealed class UpdateOrganizationCommand : ICommand<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public AddressDto? Address { get; init; }
}
