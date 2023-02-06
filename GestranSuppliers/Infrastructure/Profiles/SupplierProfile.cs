using AutoMapper;
using GestranSuppliers.Application.Responses;
using GestranSuppliers.Domain;

namespace GestranSuppliers.Infrastructure.Profiles;

public class SupplierProfile : Profile
{
    public SupplierProfile()
    {
        CreateMap<Supplier, CreateSupplierResponse>();
    }
}