using CleanArchitecture.Application.Addresses.Dto;
using CleanArchitecture.Domain.Addresses;

namespace CleanArchitecture.Application.Mappers;

public static class AddressMapper
{
    public static AddressResponse ToAddressResponse(this Address address)
    {
        return new AddressResponse
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
