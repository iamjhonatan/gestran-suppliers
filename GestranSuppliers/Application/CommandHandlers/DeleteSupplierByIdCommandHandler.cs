using System.Net;
using GestranSuppliers.Application.Commands;
using GestranSuppliers.Application.Interfaces;
using GestranSuppliers.Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GestranSuppliers.Application.CommandHandlers;

public class DeleteSupplierByIdCommandHandler : IRequestHandler<DeleteSupplierByIdCommand, ResponseResult>
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IAddressRepository _addressRepository;

    public DeleteSupplierByIdCommandHandler(ISupplierRepository supplierRepository, IAddressRepository addressRepository)
    {
        _supplierRepository = supplierRepository;
        _addressRepository = addressRepository;
    }
    
    public async Task<ResponseResult> Handle(DeleteSupplierByIdCommand request, CancellationToken cancellationToken)
    {
        var supplier = _supplierRepository.Get()
            .Include(x => x.Addresses)
            .FirstOrDefault(x => x.Id == request.Id);

        if (supplier is null)
            return new ResponseResult(false, "Supplier not found.", HttpStatusCode.NotFound);

        _addressRepository.DeleteAddresses(supplier.Addresses);

        _supplierRepository.DeleteSupplierById(supplier);

        await _supplierRepository.SaveAsync(cancellationToken);

        return new ResponseResult(true, "Supplier deleted.", HttpStatusCode.OK);
    }
}