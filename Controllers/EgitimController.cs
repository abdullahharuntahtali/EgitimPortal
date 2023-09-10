using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Views.Login;

namespace WebApplication1.Controllers
{
    public class EgitimController: Controller
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




        [HttpGet]
        public IActionResult GetKategori()
        {

            var selectListItems = _context.Kategoriler.Select(category => new SelectListItem
            {
                Text = category.KategoriAdi,
                Value = category.KategoriId.ToString() // Map KategoriId to Value
            }).ToList();
            ViewBag.Kategori = selectListItems;
            return Json(selectListItems);
        }

        [HttpGet]
        public IActionResult GetIcerik(int KategoriId)
        {
            var selectListItems = _context.Icerikler.Where(a => a.KategoriId == KategoriId).Select(icerik => new SelectListItem
            {
                Text = icerik.IcerikAdi,
                Value = icerik.IcerikID.ToString() // Map IcerikID to Value
            }).ToList();
            return Json(selectListItems);
        }


       



        public EgitimController(ApplicationDbContext context)
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
                            EgitmenAdi = kullanici.Ad+" "+ kullanici.Soyad,
                            KontenjanSayisi = egitim.KontenjanSayisi,
                            Maliyet = egitim.Maliyet,
                            Link = egitim.Link,
                            SureBilgileri = egitim.SureBilgileri

                        };

   
            ViewBag.Egitimler = query;

            return View();
        }

        public IActionResult Kategoriler()
        {
            return View();
        }

        public IActionResult Icerikler()
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
                            EgitimID=egitim.EgitimID,
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

            var query1 = from ij in query
                        join k in _context.KullaniciEgitimBilgileri
                        on ij.EgitimID equals k.EgitimId
                        join kullanici in _context.Kullanicilar
                        on k.KullaniciId equals kullanici.KullaniciId

                         select new
                        {
                            EgitimAdi = ij.EgitimAdi,
                            KategoriAdi = ij.KategoriAdi,
                            IcerikAdi = ij.IcerikAdi,
                            Resim = ij.Resim,
                            EgitmenAdi = ij.EgitmenAdi,
                            KontenjanSayisi = ij.KontenjanSayisi,
                            Maliyet = ij.Maliyet,
                            Link = ij.Link,
                            SureBilgileri = ij.SureBilgileri


                        };


            ViewBag.Egitimler = query;

            return View();
           
        }

        public IActionResult EgitimEkle()
        {
            return View();
        }

        public IActionResult KategoriEkle()
        {
            return View();
        }

        public IActionResult IcerikEkle()
        {
            return View();
        }




    }
}
