using System.Runtime.InteropServices.ComTypes;
using MegaApi.DAL.DataRepositories.Images;
using MegaApi.DAL.DataRepositories.Vendors;
using MegaApi.Models;
using MegaApi.Models.Enums;
using MegaApi.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MegaApi.DAL.DataRepositories.Products;

public class ProductsRepository : IRepository<Product>
{
    private DataContext _context { get; init; }
    private IRepository<Image> _imageRepo { get; init; }
    private IRepository<Vendor> _vendorRepo { get; init; }
    
    public ProductsRepository(DataContext context, IRepository<Image> imageRepo, IRepository<Vendor> vendorRepo)
    {
        _context    = context    ?? throw new ArgumentNullException(nameof(context));
        _imageRepo  = imageRepo  ?? throw new ArgumentNullException(nameof(imageRepo));
        _vendorRepo = vendorRepo ?? throw new ArgumentNullException(nameof(vendorRepo));
    }
    
    
    // -------- Interface implementation ---------
    
    
    public IEnumerable<Product> Get()
    {
        var products = _context.Products.ToList();
            products.InitializeImages(_imageRepo as ImagesRepository);
            products.InitializeVendors(_vendorRepo as VendorsRepository);
        
        return products;
    }
    
    public Product? GetById(int id)
    {
        return this.Get().FirstOrDefault(p => p.ProductId == id);
    }

    public void Insert(Product entity)
    {
        _context.Products.Add(entity);
    }

    public void Remove(Product entity)
    {
        _context.Products.Remove(entity);
    }

    public void Remove(int id)
    {
        _context.Products.Remove(_context.Products.FirstOrDefault(p => p.ProductId == id)!);
    }

    public void Update(Product entity)
    {
        _context.Update(entity);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
    
    
    // ----------------------------------------------
    

    public IEnumerable<Product> GetByCategory(int id)
    {
        if (id == (int)ProductType.All)
        {
            return this.Get();
        }
        
        return this.Get().Where(p => (int)p.Type == id);
    }

    public Product? GetBySlug(string slug)
    {
        return this.Get().FirstOrDefault(p => p.Slug == slug);
    }
}