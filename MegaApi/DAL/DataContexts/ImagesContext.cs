using MegaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaApi.DAL.DataContexts;

public class ImagesContext : DbContext
{
    public DbSet<Image> Images { get; set; }

    private IConfiguration _config;
    
    private string _connectionString => _config.GetConnectionString("Postgres")!;

    public ImagesContext(IConfiguration config)
    {
        _config = config;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Image>()
            .HasOne<Product>()
            .WithOne();

        modelBuilder.Entity<Image>()
            .HasOne<Vendor>()
            .WithOne();
    }
}