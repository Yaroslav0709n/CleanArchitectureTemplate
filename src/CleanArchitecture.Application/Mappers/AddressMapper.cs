using CleanArchitecture.Application.Dtos.Addresses;
using CleanArchitecture.Domain.Addresses;

namespace CleanArchitecture.Application.Mappers;

public static class AddressMapper
{
    public static AddressDto ToAddressDto(this Address address)
    {
        return new AddressDto
        {
            City = address.City,
            Street = address.Street,
            HomeNumber = address.HomeNumber,
            ApartmentNumber = address.ApartmentNumber,
            ZipCode = address.ZipCode,
            MailBox = address.MailBox
        };
    }
}
