using GestranSuppliers.Application.Interfaces;
using GestranSuppliers.Domain;

namespace GestranSuppliers.Infrastructure.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly DataContext _dataContext;

    public SupplierRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<Supplier> CreateSupplierAsync(Supplier supplier, CancellationToken cancellationToken = default)
    {
        await _dataContext.Suppliers.AddAsync(supplier, cancellationToken);

        return supplier;
    }

    public Task<Supplier> GetSupplierByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Supplier>> GetAllSuppliersAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> UpdateSupplier(Supplier supplier)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> DeleteSupplierById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task SaveAsync(CancellationToken cancellationToken = default)
    {
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}