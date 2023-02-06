using GestranSuppliers.Domain;

namespace GestranSuppliers.Application.Interfaces;

public interface IAddressRepository
{
    Task<Address> CreateAddressAsync(Address address);
    Task<IEnumerable<Address>>CreateAddressRangeAsync(IEnumerable<Address> addresses);
    Task<Address> GetAddressByIdAsync(Guid id);
    Task<IEnumerable<Address>> GetAllAddressAsync();
    Task<Guid> UpdateAddressAsync(Address address);
    Task<Guid> DeleteAddressById(Guid id);
}