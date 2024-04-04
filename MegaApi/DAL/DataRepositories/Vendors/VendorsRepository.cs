using MegaApi.DAL.DataContexts;
using MegaApi.DAL.DataRepositories.Images;
using MegaApi.Models;
using MegaApi.Models.Interfaces;

namespace MegaApi.DAL.DataRepositories.Vendors;

public class VendorsRepository : IRepository<Vendor>
{
    private VendorsContext _context { get; init; }
    
    private IRepository<Image> _imageRepo { get; init; }

    public VendorsRepository(VendorsContext context, IRepository<Image> imageRepo)
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
        var vendor = _context.Vendors.FirstOrDefault(v => v.VendorId == id);
           (vendor as IHasImage)!.InitializeImage(_imageRepo as ImagesRepository);

        return vendor;
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