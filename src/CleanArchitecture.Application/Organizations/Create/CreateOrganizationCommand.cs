using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Addresses.Dto;

namespace CleanArchitecture.Application.Organizations.Create;

public sealed class CreateOrganizationCommand : ICommand<Guid>
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public AddressDto? Address { get; init; }
}
