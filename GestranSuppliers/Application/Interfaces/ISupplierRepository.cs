using GestranSuppliers.Domain;

namespace GestranSuppliers.Application.Interfaces;

public interface ISupplierRepository
{
    Task<Supplier> CreateSupplierAsync(Supplier supplier, CancellationToken cancellationToken = default);
    Task<Supplier> GetSupplierByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Supplier>> GetAllSuppliersAsync(CancellationToken cancellationToken = default);
    Supplier UpdateSupplier(Supplier supplier);
    Task<Guid> DeleteSupplierById(Guid id);
    Task SaveAsync(CancellationToken cancellationToken = default);
}