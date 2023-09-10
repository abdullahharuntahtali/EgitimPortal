using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Egitim
    {
        [Key]
        public int EgitimID { get; set; }
        public string EgitimAdi { get; set; }
        public int Kategori { get; set; }
        public int Icerik { get; set; }
        public string Resim { get; set; }
        public int Egitmen { get; set; }
        public int KontenjanSayisi { get; set; }
        public float Maliyet { get; set; }
        public string Link { get; set; }
        public string SureBilgileri { get; set; }

        // İlişkiler
  

    }
}
