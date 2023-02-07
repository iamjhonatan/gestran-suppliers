using GestranSuppliers.Application.Responses;
using MediatR;

namespace GestranSuppliers.Application.Queries;

public class GetSupplierByIdQuery : IRequest<ResponseResult>
{
    public GetSupplierByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}