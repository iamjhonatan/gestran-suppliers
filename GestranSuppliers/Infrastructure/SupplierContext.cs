using GestranSuppliers.Domain;
using Microsoft.EntityFrameworkCore;

namespace GestranSuppliers.Infrastructure;

public class SupplierContext : DbContext
{
    public SupplierContext(DbContextOptions<SupplierContext> options) : base(options)
    { }

    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Address> Addresses { get; set; }
}