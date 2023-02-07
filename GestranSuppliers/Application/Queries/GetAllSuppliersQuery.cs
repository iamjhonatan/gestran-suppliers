using GestranSuppliers.Application.Responses;
using MediatR;

namespace GestranSuppliers.Application.Queries;

public class GetAllSuppliersQuery : IRequest<ResponseResult>
{
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public string City { get; set; }

    public int Offset { get; set; } = 1;
    public int Limit { get; set; } = 10;
}