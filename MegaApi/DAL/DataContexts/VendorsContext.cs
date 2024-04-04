using MegaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaApi.DAL.DataContexts;

public class VendorsContext : DbContext
{
    public DbSet<Vendor> Vendors { get; set; }

    private IConfiguration _config { get; init; }
    
    private string _connectionString => _config.GetConnectionString("Postgres")!;

    public VendorsContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vendor>()
            .HasOne<Image>()
            .WithOne();
    }
}