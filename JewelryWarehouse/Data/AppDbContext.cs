using JewelryWarehouse.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace JewelryWarehouse.Data;

public class AppDbContext : DbContext
{
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Inventory> Inventories { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shop>()
            .HasOne(s => s.Address)
            .WithOne(a => a.Shop)
            .HasForeignKey<Address>(a => a.ShopId);

        modelBuilder.Entity<Warehouse>()
            .HasOne(w => w.Shop)
            .WithMany(s => s.Warehouses)
            .HasForeignKey(w => w.ShopId);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Categories)
            .WithMany(c => c.Products)
            .UsingEntity(j => j.ToTable("ProductCategory"));

        modelBuilder.Entity<Inventory>()
            .HasOne(i => i.Warehouse)
            .WithMany(w => w.Inventories)
            .HasForeignKey(i => i.WarehouseId);
    }
}