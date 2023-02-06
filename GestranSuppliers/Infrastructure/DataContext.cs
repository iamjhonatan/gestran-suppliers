using GestranSuppliers.Domain;
using Microsoft.EntityFrameworkCore;

namespace GestranSuppliers.Infrastructure;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }

    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Supplier>().ToTable("Suppliers");
        modelBuilder.Entity<Supplier>().Property(x => x.Id);
        modelBuilder.Entity<Supplier>().Property(x => x.Name).HasMaxLength(120).HasColumnType("varchar(120)");
        modelBuilder.Entity<Supplier>().Property(x => x.Cnpj).HasMaxLength(18).HasColumnType("varchar(18)");
        modelBuilder.Entity<Supplier>().Property(x => x.PhoneNumber).HasMaxLength(18).HasColumnType("varchar(18)");
        modelBuilder.Entity<Supplier>().Property(x => x.Email).HasMaxLength(256).HasColumnType("varchar(256)");
        modelBuilder.Entity<Supplier>().Property(x => x.CreatedAt).HasColumnType("datetime2").HasPrecision(0);
        modelBuilder.Entity<Supplier>().Property(x => x.UpdatedAt).HasColumnType("datetime2").HasPrecision(0);

        modelBuilder.Entity<Address>().ToTable("Addresses");
        modelBuilder.Entity<Address>().Property(x => x.Id);
        modelBuilder.Entity<Address>().Property(x => x.ZipCode).HasMaxLength(10).HasColumnType("varchar(10)");
        modelBuilder.Entity<Address>().Property(x => x.PublicPlace).HasMaxLength(120).HasColumnType("varchar(120)");
        modelBuilder.Entity<Address>().Property(x => x.Number).HasMaxLength(12).HasColumnType("varchar(12)");
        modelBuilder.Entity<Address>().Property(x => x.Complement).HasMaxLength(64).HasColumnType("varchar(64)");
        modelBuilder.Entity<Address>().Property(x => x.City).HasMaxLength(120).HasColumnType("varchar(120)");
        modelBuilder.Entity<Address>().Property(x => x.State).HasMaxLength(120).HasColumnType("varchar(120)");
        modelBuilder.Entity<Address>().Property(x => x.Country).HasMaxLength(120).HasColumnType("varchar(120)");
        modelBuilder.Entity<Address>().HasOne(x => x.Supplier).WithMany(x => x.Addresses)
            .HasForeignKey(x => x.SupplierId);
    }
}