using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Dtos.Addresses;

namespace CleanArchitecture.Application.Organizations.Create;

public class CreateOrganizationCommand : ICommand<Guid>
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public AddressDto? Address { get; init; }
}
