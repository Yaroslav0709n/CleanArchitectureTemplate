using CleanArchitecture.Application.Addresses.Dto;

namespace CleanArchitecture.Application.Organizations.Dto;

public sealed class OrganizationResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public AddressResponse? Address { get; set; }
}