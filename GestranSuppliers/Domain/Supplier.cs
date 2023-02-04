namespace GestranSuppliers.Domain;

public class Supplier
{
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public List<Address> Addresses { get; set; }
}