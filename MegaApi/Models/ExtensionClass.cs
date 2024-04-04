using MegaApi.DAL.DataRepositories.Images;
using MegaApi.DAL.DataRepositories.Vendors;
using MegaApi.Models.Interfaces;

namespace MegaApi.Models;

public static class ExtensionClass
{
    public static void InitializeImages(this IEnumerable<IHasImage> collection, ImagesRepository repo)
    {
        foreach (var entity in collection)
        {
            entity.InitializeImage(repo);
        }
    }

    public static void InitializeVendors(this IEnumerable<Product> products, VendorsRepository repo)
    {
        foreach (var product in products)
        {
            product.InitializeVendor(repo);
        }
    }
}