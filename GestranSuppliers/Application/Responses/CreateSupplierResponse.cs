namespace GestranSuppliers.Application.Responses;

public class CreateSupplierResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<CreateAddressResponse> Addresses { get; set; }
}