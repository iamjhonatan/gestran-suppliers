using GestranSuppliers.Application.Interfaces;
using GestranSuppliers.Domain;

namespace GestranSuppliers.Infrastructure.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly DataContext _dataContext;

    public AddressRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<Address>> CreateAddressRangeAsync(IEnumerable<Address> addresses)
    {
        await _dataContext.AddRangeAsync(addresses);

        return addresses;
    }

    public IEnumerable<Address> UpdateAddress(IEnumerable<Address> addresses)
    {
        _dataContext.UpdateRange(addresses);

        return addresses;
    }

    public IEnumerable<Address> DeleteAddresses(IEnumerable<Address> addresses)
    {
        _dataContext.Addresses.RemoveRange(addresses);

        return addresses;
    }
}