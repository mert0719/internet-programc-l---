using System.ComponentModel.DataAnnotations;

namespace portal.Models
{
    public class Ogrenci
    {
        [Key]
        public int Id { get; set; }
        public int userId { get; set; }
        public virtual AppUser user { get; set; }

    }
}
