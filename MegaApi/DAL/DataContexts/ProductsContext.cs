using MegaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaApi.DAL.DataContexts;

public class ProductsContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    private IConfiguration _config;
    
    private string _connectionString => _config.GetConnectionString("Postgres")!;
    
    public ProductsContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseNpgsql(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
            .HasOne<Image>()
            .WithOne();

        builder.Entity<Product>()
            .HasOne<Vendor>()
            .WithMany();
    }
}