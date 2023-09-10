using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Controllers
{
    public class KullaniciController:Controller
    {
        private readonly ApplicationDbContext _context;
        public async Task<IActionResult> Index()
        {
            //var selectListItems = _context.Kategoriler.Select(category => new SelectListItem
            //{
            //    Text = category.KategoriAdi,
            //    Value = category.KategoriId.ToString() // Map KategoriId to Value
            //}).ToList();
            //ViewBag.Kategori = selectListItems;



            return View();
        }


        public KullaniciController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Icerik()
        {

            var query = from egitim in _context.Egitimler
                        join icerik in _context.Icerikler
                        on egitim.Icerik equals icerik.IcerikID
                        join kategori in _context.Kategoriler
                        on icerik.KategoriId equals kategori.KategoriId
                        join kullanici in _context.Kullanicilar
                        on egitim.Egitmen equals kullanici.KullaniciId
                        select new
                        {
                            EgitimAdi = egitim.EgitimAdi,
                            KategoriAdi = kategori.KategoriAdi,
                            IcerikAdi = icerik.IcerikAdi,
                            Resim = egitim.Resim,
                            EgitmenAdi = kullanici.Ad + " " + kullanici.Soyad,
                            KontenjanSayisi = egitim.KontenjanSayisi,
                            Maliyet = egitim.Maliyet,
                            Link = egitim.Link,
                            SureBilgileri = egitim.SureBilgileri

                        };


            ViewBag.Egitimler = query;

            return View();
        }

        public IActionResult AlinanEgitimler()
        {

            return View();
        }

        public IActionResult BitirilenEgitimler()
        {

            return View();
        }
    }
}
