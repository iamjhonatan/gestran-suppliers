using GestranSuppliers.Application.Interfaces;
using GestranSuppliers.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Supplier> GetSupplierByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var supplier = _dataContext.Suppliers
            .Include(x => x.Addresses)
            .FirstOrDefault(x => x.Id == id);

        return supplier;
    }

    public Task<IEnumerable<Supplier>> GetAllSuppliersAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Supplier UpdateSupplier(Supplier supplier)
    {
        _dataContext.Update(supplier);

        return supplier;
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