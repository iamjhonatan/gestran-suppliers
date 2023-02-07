using System.Net;
using AutoMapper;
using GestranSuppliers.Application.Interfaces;
using GestranSuppliers.Application.Queries;
using GestranSuppliers.Application.Responses;
using GestranSuppliers.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GestranSuppliers.Application.QueryHandlers;

public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, ResponseResult>
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;

    public GetAllSuppliersQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
    {
        _supplierRepository = supplierRepository;
        _mapper = mapper;
    }
    
    public async Task<ResponseResult> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
    {
        var query = CreateQueryWithFilters(request);
        
        var result = await query
            .OrderBy(x => x.Name)
            .Skip((request.Offset -1) * request.Limit)
            .Take(request.Limit).ToListAsync(cancellationToken);

        var supplierResponse = _mapper.Map<List<SupplierResponse>>(result);
        
        var pagination = new Pagination<SupplierResponse>(query.Count(), request.Offset, request.Limit, supplierResponse);
        
        return new ResponseResult(true, HttpStatusCode.OK, pagination);
    }
    
    private IQueryable<Supplier> CreateQueryWithFilters(GetAllSuppliersQuery request)
    {
        var query = _supplierRepository
            .Get()
            .Include(x => x.Addresses)
            .AsQueryable();

        if (!string.IsNullOrEmpty(request.Name))
            query = query.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
        
        if (!string.IsNullOrEmpty(request.Cnpj))
            query = query.Where(x => x.Cnpj.ToLower().Contains(request.Cnpj.ToLower()));
        
        if (!string.IsNullOrEmpty(request.City))
            query = query.Where(x => x.Addresses.Any(address => address.City.ToLower().Contains(request.City.ToLower())));
        
        return query;
    }
}