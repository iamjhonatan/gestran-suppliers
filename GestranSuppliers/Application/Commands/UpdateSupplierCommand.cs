using GestranSuppliers.Application.Responses;
using MediatR;

namespace GestranSuppliers.Application.Commands;

public class UpdateSupplierCommand : IRequest<ResponseResult>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public ICollection<UpdateAddressCommand> Addresses { get; set; }
}

public class UpdateAddressCommand
{
    public Guid Id { get; set; }
    public string ZipCode { get; set; }
    public string PublicPlace { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
}
