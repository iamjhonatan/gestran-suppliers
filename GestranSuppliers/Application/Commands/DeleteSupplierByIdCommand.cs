using GestranSuppliers.Application.Responses;
using MediatR;

namespace GestranSuppliers.Application.Commands;

public class DeleteSupplierByIdCommand : IRequest<ResponseResult>
{
    public DeleteSupplierByIdCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}