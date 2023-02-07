using System.Net;
using GestranSuppliers.API.Validators;
using GestranSuppliers.Application.Commands;
using GestranSuppliers.Application.Interfaces;
using GestranSuppliers.Application.Responses;
using GestranSuppliers.Domain;
using MediatR;

namespace GestranSuppliers.Application.CommandHandlers;

public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, ResponseResult>
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IAddressRepository _addressRepository;

    public UpdateSupplierCommandHandler(ISupplierRepository supplierRepository, IAddressRepository addressRepository)
    {
        _supplierRepository = supplierRepository;
        _addressRepository = addressRepository;
    }
    
    public async Task<ResponseResult> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
    {
        // TODO: validate input data
        
        var supplierDatabase = await _supplierRepository.GetSupplierByIdAsync(request.Id, cancellationToken);
        
        if (supplierDatabase is null)
            return new ResponseResult(false, "This supplier is not exist.", HttpStatusCode.BadRequest);

        supplierDatabase.Name = request.Name;
        supplierDatabase.Email = request.Email;
        supplierDatabase.PhoneNumber = request.PhoneNumber;
        supplierDatabase.UpdatedAt = DateTime.Now;

        var updatedAddresses = new List<Address>();

        foreach (var newAddress in request.Addresses)
        {
            var addressesValidator = new UpdateAddressCommandValidator();
            var resultAddressValidator = await addressesValidator.ValidateAsync(newAddress, cancellationToken);
            
            if (resultAddressValidator.IsValid is false)
                return new ResponseResult(false, "Error when update address.", HttpStatusCode.BadRequest, resultAddressValidator.Errors);

            var addressDatabase = supplierDatabase.Addresses.FirstOrDefault(x => x.Id == newAddress.Id);

            if (addressDatabase is null)
            {
                // TODO: create address
            }

            addressDatabase.ZipCode = newAddress.ZipCode;
            addressDatabase.PublicPlace = newAddress.PublicPlace;
            addressDatabase.Number = newAddress.Number;
            addressDatabase.Complement = newAddress.Complement;
            addressDatabase.City = newAddress.City;
            addressDatabase.State = newAddress.State;
            addressDatabase.Country = newAddress.Country;
                
            updatedAddresses.Add(addressDatabase);
        }

        supplierDatabase.Addresses = updatedAddresses;

        _supplierRepository.UpdateSupplier(supplierDatabase);

        _addressRepository.UpdateAddress(updatedAddresses);

        await _supplierRepository.SaveAsync(cancellationToken);

        return new ResponseResult(true, "Supplier successfully updated.", HttpStatusCode.Created, supplierDatabase);
    }
}