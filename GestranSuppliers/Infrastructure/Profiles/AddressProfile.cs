using AutoMapper;
using GestranSuppliers.Application.Responses;
using GestranSuppliers.Domain;

namespace GestranSuppliers.Infrastructure.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<Address, CreateAddressResponse>();
    }
}