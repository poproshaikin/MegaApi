using MegaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaApi.DAL;

public class DataContext : DbContext
{
    public DbSet<Image>   Images   { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Vendor>  Vendors  { get; set; }

    private IConfiguration _config;
    
    private string _connectionString => _config.GetConnectionString("Postgres")!;

    public DataContext(IConfiguration config)
    {
        _config = config;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne<Image>(p => p.Image)
            .WithOne()
            .HasForeignKey<Product>(p => p.ImageId);

        modelBuilder.Entity<Vendor>()
            .HasMany<Product>()
            .WithOne()
            .HasForeignKey(p => p.VendorId);

        modelBuilder.Entity<Vendor>()
            .HasOne<Image>(v => v.Image)
            .WithOne()
            .HasForeignKey<Vendor>(v => v.ImageId);
    }
}