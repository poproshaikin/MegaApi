using MegaApi.DAL.DataContexts;
using MegaApi.DAL.DataRepositories.Images;
using MegaApi.Models;
using MegaApi.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MegaApi.DAL.DataRepositories.Products;

public class ProductsRepository : IRepository<Product>
{
    private ProductsContext _context { get; init; }
    private IRepository<Image> _imageRepo { get; init; }
    
    public ProductsRepository(ProductsContext context, IRepository<Image> imageRepo)
    {
        _context = context     ?? throw new ArgumentNullException(nameof(context));
        _imageRepo = imageRepo ?? throw new ArgumentNullException(nameof(imageRepo));
    }
    
    
    // -------- Interface implementation ---------
    
    
    public IEnumerable<Product> Get()
    {
        var products = _context.Products.ToList();
            products.InitializeImages(_imageRepo as ImagesRepository);
        
        return products;
    }
    
    public Product? GetById(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
           (product as IHasImage).InitializeImage(_imageRepo as ImagesRepository);
           
        return product;
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
        return this.Get().Where(p => (int)p.Type == id);
    }

    public Product? GetBySlug(string slug)
    {
        return this.Get().FirstOrDefault(p => p.Slug == slug);
    }
}