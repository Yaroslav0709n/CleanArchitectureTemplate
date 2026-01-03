namespace CleanArchitecture.Application.Dtos.Addresses;

public sealed class OrganizationResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public AddressDto? Address { get; set; }
}