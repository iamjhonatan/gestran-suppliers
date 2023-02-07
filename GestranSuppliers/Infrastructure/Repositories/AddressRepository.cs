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
    
    public async Task<Address> CreateAddressAsync(Address address)
    {
        _dataContext.Addresses.Add(address);
        await _dataContext.SaveChangesAsync();

        return address;
    }

    public async Task<IEnumerable<Address>> CreateAddressRangeAsync(IEnumerable<Address> addresses)
    {
        await _dataContext.AddRangeAsync(addresses);

        return addresses;
    }

    public async Task<Address> GetAddressByIdAsync(Guid id)
    {
        return _dataContext.Addresses.FirstOrDefault(x => x.Id == id);
    }

    public Task<IEnumerable<Address>> GetAllAddressAsync()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Address> UpdateAddress(IEnumerable<Address> addresses)
    {
        _dataContext.UpdateRange(addresses);

        return addresses;
    }

    public Task<Guid> DeleteAddressById(Guid id)
    {
        throw new NotImplementedException();
    }
}