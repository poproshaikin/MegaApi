using MegaApi.DAL.DataRepositories.Images;

namespace MegaApi.Models.Interfaces;

public interface IHasImage
{
    int? ImageId { get; }
    Image? Image { get; }

    void SetImage(Image img);

    void InitializeImage(ImagesRepository repo)
    {
        if (ImageId == null)
        {
            Console.WriteLine("   WARNING:");
            Console.WriteLine("      Attempted to initialize image via ImageId while was null");
            Console.WriteLine("      IHasImage.InitializeImage(ImagesRepository repo");
            return;
        }
        
        this.SetImage(repo.GetById(this.ImageId.Value)!);
        this.Image?.ReadImageData();
    }
}