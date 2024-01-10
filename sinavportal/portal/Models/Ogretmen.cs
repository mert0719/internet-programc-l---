using System.ComponentModel.DataAnnotations;

namespace portal.Models
{
    public class Ogretmen
    {
        [Key]
        public int Id { get; set; }
        public int appuserId { get; set; }
        public virtual AppUser appuser { get; set; }
    }
}
