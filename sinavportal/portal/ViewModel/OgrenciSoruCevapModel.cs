namespace portal.ViewModel
{
    public class OgrenciSoruCevapModel
    {
        public int Id { get; set; }
        public string Soru { get; set; }
        public string Cevap { get; set; }
        public int SoruPuan { get; set; }
        public int? CevapPuani { get; set; }
        public int? userId { get; set; }
    }
}
