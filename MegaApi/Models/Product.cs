using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MegaApi.Models.Enums;
using MegaApi.Models.Interfaces;

namespace MegaApi.Models;

public class Product : IHasImage
{
    [Key]       public int         ProductId   { get; set; }
                public int         VendorId    { get; set; }
                public int         ImageId     { get; set; }
    
                public string      Name        { get; set; } 
                public string      Description { get; set; }
                public double      Price       { get; set; }
                public ProductType Type        { get; set; }
    
                public string[]    Keywords    { get; set; }
                public string      Slug        { get; set; }
    
    [NotMapped] public Vendor?     Vendor      { get; set; }
    [NotMapped] public Image?      Image       { get; set; }

    public void SetImage(Image img)
    {
        Image = img;
    }
}