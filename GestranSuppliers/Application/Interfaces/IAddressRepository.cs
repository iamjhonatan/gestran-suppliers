using GestranSuppliers.Domain;

namespace GestranSuppliers.Application.Interfaces;

public interface IAddressRepository
{
    Task<IEnumerable<Address>> CreateAddressRangeAsync(IEnumerable<Address> addresses);
    IEnumerable<Address> UpdateAddress(IEnumerable<Address> addresses);
    IEnumerable<Address> DeleteAddresses(IEnumerable<Address> addresses);
}