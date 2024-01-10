using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace portal.Models
{
    public class Context : IdentityDbContext<UserApp , UserAppRole , int>
    {

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-0GOFGPR\\SQLEXPRESS;Initial Catalog=OdevPortal; TrustServerCertificate=True; Integrated Security=True;");
        //}

        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ogretmen> ogretmens { get; set; }
        public DbSet<Ogrenci> ogrencis { get; set; }       
        public DbSet<AppUser> users { get; set; }
        public DbSet<Sorular> sorulars { get; set; }
        public DbSet<Cevaplar> cevaplars { get; set; }
        public DbSet<OgrenciSoruCevap> ogrenciSoruCevaps { get; set; }


    }
}

//Migration işlemi : Tabloları veritabanına code first yolu ile eklemek için add-migration yazıp boşluk bırakıp yanına rastgele bir isim yazıyoruz
//add-migrationu yazacağımız alan package manage console
//veritabanı classı hangi katmanda ise yani hangi projede ise o proje seçilecek
//Migrationu oluşturduktan sonra update-database komutu ile tabloları veritabanına yansıtıyoruz