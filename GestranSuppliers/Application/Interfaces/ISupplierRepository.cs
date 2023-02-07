using GestranSuppliers.Domain;

namespace GestranSuppliers.Application.Interfaces;

public interface ISupplierRepository
{
    Task<Supplier> CreateSupplierAsync(Supplier supplier, CancellationToken cancellationToken = default);
    Task<Supplier> GetSupplierByIdAsync(Guid id, CancellationToken cancellationToken = default);
    IQueryable<Supplier> Get();
    Supplier UpdateSupplier(Supplier supplier);
    void DeleteSupplierById(Supplier supplier);
    Task SaveAsync(CancellationToken cancellationToken = default);
}