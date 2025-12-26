using CleanArchitecture.Domain.Addresses;

namespace CleanArchitecture.Domain.Organizations;

public class Organization : BaseEntity
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public Address? Address { get; set; }
}