using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {






            return View();
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Remove("user");
            //System.Diagnostics.Process.Start("dotnet", "WebApplication1.dll");
            Process.Start("dotnet", "run --project C:\\Users\\PC\\Desktop\\Proje-Yaz\\WebApplication1\\WebApplication1.csproj");
            return Redirect("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Create(Kullanici user)
        {

            if (_context.Kullanicilar.Any(x => x.UserName == user.UserName && x.Password == user.Password && user.EgitmenMi==x.EgitmenMi))
            {

                var kullanici = _context.Kullanicilar.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
                bool egitmen = user.EgitmenMi == kullanici.EgitmenMi;


                if (kullanici != null)
                {


                    string appUserJson = JsonSerializer.Serialize<Kullanici>(kullanici);

                    HttpContext.Session.SetString("user", appUserJson);



                    if (kullanici.EgitmenMi)
                    {

                        return RedirectToRoute(new { controller = "Egitim", action = "Index" });
                    }
                    else
                    {
                        return RedirectToRoute(new { controller = "Egitim", action = "Icerik" });
                    }






                }
            }
            else
            {



                HttpContext.Session.Remove("user");
            }
            return Redirect("Index");
        }

    }
}
