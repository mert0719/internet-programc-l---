using System.ComponentModel.DataAnnotations;

namespace portal.Models
{
    public class Sorular
    {
        [Key]
        public int Id { get; set; }
        public string Soru { get; set; }
        public int SoruPuani { get; set; }
    }
}
