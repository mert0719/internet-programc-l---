using System.ComponentModel.DataAnnotations;

namespace portal.Models
{
    public class OgrenciSoruCevap
    {
        [Key]
        public int Id { get; set; }
        public int SoruId { get; set; }
        public virtual Sorular Soru { get; set; }
        public int userId { get; set; }
        public virtual AppUser User { get; set; }
        public string Cevap { get; set; }
        public int? CevapPuani { get; set; }
    }
}
