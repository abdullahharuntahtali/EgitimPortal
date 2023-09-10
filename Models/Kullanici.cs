using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Kullanici
    {
        [Key]
        public int KullaniciId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool EgitmenMi { get; set; }
        public string? EgitmenBilgisi { get; set; }
    }
}
