using System.Net;
using AutoMapper;
using FluentValidation;
using GestranSuppliers.API.Validators;
using GestranSuppliers.Application.Commands;
using GestranSuppliers.Application.Interfaces;
using GestranSuppliers.Application.Responses;
using GestranSuppliers.Domain;
using MediatR;

namespace GestranSuppliers.Application.CommandHandlers;

public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, ResponseResult>
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

    public async Task<ResponseResult> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
    {
        var supplierValidator = new CreateSupplierCommandValidator();
        var supplierResult = await supplierValidator.ValidateAsync(request, cancellationToken);

        if (supplierResult.IsValid is false)
            return new ResponseResult(false, "Errors when validate supplier data.", HttpStatusCode.BadRequest, supplierResult.Errors);

        var addressValidator = new CreateAddressCommandValidator();
        
        foreach (var address in request.Addresses)
        {
            var addressResult = await addressValidator.ValidateAsync(address, cancellationToken);
            
            if (addressResult.IsValid is false)
                return new ResponseResult(false, "Errors when validate addresses data.", HttpStatusCode.BadRequest, addressResult.Errors);
        }

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

        return new ResponseResult(true, "Supplier successfully created.", HttpStatusCode.Created, supplier.Id);
    }
}