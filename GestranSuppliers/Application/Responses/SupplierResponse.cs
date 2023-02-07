namespace GestranSuppliers.Application.Responses;

public class SupplierResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<AddressResponse> Addresses { get; set; }
}