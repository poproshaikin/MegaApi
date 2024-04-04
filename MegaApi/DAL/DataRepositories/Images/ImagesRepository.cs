using MegaApi.Models;

namespace MegaApi.DAL.DataRepositories.Images;

public class ImagesRepository : IRepository<Image>
{
    private DataContext _context { get; init; }

    public ImagesRepository(DataContext context)
    {
        _context = context;
    }
    
    // ----- Interface implementation -----

    public IEnumerable<Image> Get()
    {
        return _context.Images.ToList();
    }

    public Image? GetById(int id)
    {
        return _context.Images.FirstOrDefault(i => i.ImageId == id);
    }

    public void Insert(Image entity)
    {
        _context.Images.Add(entity);
    }

    public void Remove(Image entity)
    {
        _context.Images.Remove(entity);
    }

    public void Remove(int id)
    {
        _context.Images.Remove(_context.Images.FirstOrDefault(i => i.ImageId == id)!);
    }

    public void Update(Image entity)
    {
        _context.Images.Update(entity);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
    
    // ----- ----- ----- ----- ----- -----
}