using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaApi.Models;

public class Image
{
    [Key]       public int        ImageId    { get; set; }
                public string?    Name       { get; set; }
                public string     Path       { get; set; }
    
    [NotMapped] public byte[] ImageData      { get; set; }

    public void ReadImageData()
    {
        ImageData = File.ReadAllBytes(Path);
    }
}