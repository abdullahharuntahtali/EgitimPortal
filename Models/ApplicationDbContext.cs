using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { 
    }
    public DbSet<Kategori> Kategoriler { get; set; }
    public DbSet<Kullanici> Kullanicilar { get; set; }
    public DbSet<Egitim> Egitimler { get; set; }
    public DbSet<Icerik> Icerikler { get; set; }
    public DbSet<KullaniciEgitimBilgisi> KullaniciEgitimBilgileri { get; set; }

}