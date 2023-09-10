using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Icerik
    {
        [Key]
        public int IcerikID { get; set; }
        public int KategoriId { get; set; }
        public string IcerikAdi { get; set; }
    }
}
