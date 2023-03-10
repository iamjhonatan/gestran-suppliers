namespace GestranSuppliers.Application.Responses;

public class AddressResponse
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