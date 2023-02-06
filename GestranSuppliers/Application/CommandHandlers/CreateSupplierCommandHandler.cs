using AutoMapper;
using GestranSuppliers.Application.Commands;
using GestranSuppliers.Application.Interfaces;
using GestranSuppliers.Application.Responses;
using GestranSuppliers.Domain;
using MediatR;

namespace GestranSuppliers.Application.CommandHandlers;

public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, CreateSupplierResponse>
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;

    public CreateSupplierCommandHandler(ISupplierRepository supplierRepository, IAddressRepository addressRepository, IMapper mapper)
    {
        _supplierRepository = supplierRepository;
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public async Task<CreateSupplierResponse> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
    {
        var supplier = new Supplier
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Cnpj = request.Cnpj,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            CreatedAt = DateTime.Now
        };
        
        var addresses = new List<Address>();

        foreach (var requestAddress in request.Addresses)
        {
            var address = new Address
            {
                Id = Guid.NewGuid(),
                ZipCode = requestAddress.ZipCode,
                PublicPlace = requestAddress.PublicPlace,
                Number = requestAddress.Number,
                Complement = requestAddress.Complement,
                City = requestAddress.City,
                State = requestAddress.State,
                Country = requestAddress.Country,
                SupplierId = supplier.Id
            };
            
            addresses.Add(address);
        }
        
        await _supplierRepository.CreateSupplierAsync(supplier, cancellationToken);

        await _addressRepository.CreateAddressRangeAsync(addresses);

        await _supplierRepository.SaveAsync(cancellationToken);

        return _mapper.Map<CreateSupplierResponse>(supplier);
    }
}