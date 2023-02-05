namespace GestranSuppliers.Domain;

public class Supplier
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ICollection<Address> Addresses { get; set; }
}