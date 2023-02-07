using System.Net;
using AutoMapper;
using GestranSuppliers.Application.Interfaces;
using GestranSuppliers.Application.Queries;
using GestranSuppliers.Application.Responses;
using MediatR;

namespace GestranSuppliers.Application.QueryHandlers;

public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, ResponseResult>
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;

    public GetSupplierByIdQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
    {
        _supplierRepository = supplierRepository;
        _mapper = mapper;
    }
    
    public async Task<ResponseResult> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _supplierRepository.GetSupplierByIdAsync(request.Id, cancellationToken);
        
        if (result is null)
            return new ResponseResult(false, "Supplier not found.", HttpStatusCode.NotFound);

        var supplierResult = _mapper.Map<SupplierResponse>(result);

        return new ResponseResult(true, "Supplier founded.", HttpStatusCode.OK, supplierResult);
    }
}