using MegaApi.DAL.DataRepositories.Images;
using MegaApi.Models.Interfaces;

namespace MegaApi.Models;

public static class ExtensionClass
{
    public static void InitializeImages(this IEnumerable<IHasImage> collection, ImagesRepository repo)
    {
        foreach (var entity in collection)
        {
            entity.InitializeImage(repo);

            // product.SetImage(repo.GetById(product.ImageId)!);
            // product.Image?.ReadImageData();
        }
    }
}