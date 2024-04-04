using MegaApi.DAL.DataRepositories.Images;

namespace MegaApi.Models.Interfaces;

public interface IHasImage
{
    int ImageId { get; }
    Image? Image { get; }

    void SetImage(Image img);

    void InitializeImage(ImagesRepository repo)
    {
        this.SetImage(repo.GetById(this.ImageId)!);
        this.Image?.ReadImageData();
    }
}