namespace portal.Models
{
    public class Cevaplar
    {
        public int Id { get; set; }
        public string Cevap { get; set; }
        public int SorularId { get; set; }
        public virtual Sorular Sorular { get; set; }
    }
}
