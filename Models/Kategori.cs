using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
    }
}
