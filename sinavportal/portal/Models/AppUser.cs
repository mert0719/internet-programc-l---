using System.ComponentModel.DataAnnotations;

namespace portal.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Rol { get; set; }
        public string Gorsel { get; set; }
    }
}
