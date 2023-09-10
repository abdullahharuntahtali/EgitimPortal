using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class KullaniciEgitimBilgisi
    {
        [Key]
        public int AlinanEgitimId { get; set; }
        public int EgitimId { get; set; }
        public int KullaniciId { get; set; }
        public DateTime? AlmaTarihi { get; set; }
        public DateTime? TamamlamaTarihi { get; set; }
        public int KalinanYer { get; set; }

        // İlişkiler
        public Kullanici Kullanici { get; set; }
        public Egitim Egitim { get; set; }
    }
}
