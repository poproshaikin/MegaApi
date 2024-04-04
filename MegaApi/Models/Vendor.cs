using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MegaApi.DAL.DataRepositories.Images;
using MegaApi.Models.Enums;
using MegaApi.Models.Interfaces;

namespace MegaApi.Models;

public class Vendor : IHasImage
{
    [Key] public int VendorId { get; set; }
    public int ImageId { get; set; }
    
    public string Username { get; set; }
    public string FullName { get; set; }
    public string ContactNumber { get; set; }
    public string ContactEmail { get; set; }
    public VendorType Type { get; set; }

    public string[] Keywords { get; set; }
    public string Slug { get; private set; }

    [NotMapped] public Image? Image { get; set; }

    public void SetImage(Image img)
    {
        Image = img;
    }
}