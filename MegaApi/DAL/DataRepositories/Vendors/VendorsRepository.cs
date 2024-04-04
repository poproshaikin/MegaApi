using MegaApi.DAL.DataRepositories.Images;
using MegaApi.Models;
using MegaApi.Models.Interfaces;

namespace MegaApi.DAL.DataRepositories.Vendors;

public class VendorsRepository : IRepository<Vendor>
{
    private DataContext _context { get; init; }
    
    private IRepository<Image> _imageRepo { get; init; }

    public VendorsRepository(DataContext context, IRepository<Image> imageRepo)
    {
        _context   = context   ?? throw new ArgumentNullException(nameof(context));
        _imageRepo = imageRepo ?? throw new ArgumentNullException(nameof(imageRepo));
    }
    
    
    // ----------- Interface implementation -----------
    

    public IEnumerable<Vendor> Get()
    {
        var vendors = _context.Vendors.ToList();
            vendors.InitializeImages(_imageRepo as ImagesRepository);

        return vendors;
    }

    public Vendor? GetById(int id)
    {
        return this.Get().FirstOrDefault(v => v.VendorId == id);
    }

    public void Insert(Vendor entity)
    {
        _context.Vendors.Add(entity);
    }

    public void Remove(Vendor entity)
    {
        _context.Vendors.Remove(entity);
    }

    public void Remove(int id)
    {
        _context.Vendors.Remove(_context.Vendors.FirstOrDefault(v => v.VendorId == id));
    }

    public void Update(Vendor entity)
    {
        _context.Vendors.Update(entity);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
    
    
    // -------------------------------------------------
}