using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using portal.Models;
using portal.ViewModel;

namespace portal.Controllers
{
    public class SorularController : Controller
    {
        private readonly Context _c;

        public SorularController(Context c)
        {
            _c = c;
        }

        public IActionResult Index()
        {
            var values = _c.sorulars.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Sorular soruss)
        {
            Sorular sorular = new Sorular();
            sorular.Soru = soruss.Soru;
            sorular.SoruPuani = soruss.SoruPuani;
            _c.sorulars.Add(sorular);
            _c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Sil(int id)
        {
            var values = _c.sorulars.Find(id);
            _c.sorulars.Remove(values);
            _c.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Duzenle(int id)
        {
            var values = _c.sorulars.Find(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Duzenle(Sorular sorulars_, int id)
        {
            var values = _c.sorulars.Find(id);
            values.Soru = values.Soru;
            values.SoruPuani = sorulars_.SoruPuani;
            _c.sorulars.Update(values);
            _c.SaveChanges();
            return RedirectToAction("Index");
        }



        ////--------------------------------------------------
        ////Ajax ile yapıldı
        public IActionResult Sorularim()
        {
            
            var values = _c.sorulars
                .Select(x => new SoruModel
                {
                   Id = x.Id,
                   Soru = x.Soru,                   
                }).ToList();
            return View(values);

        }

        [HttpGet]
        public IActionResult CevapVer(int Id)
        {
            var values = _c.sorulars.Find(Id);
            ViewBag.soru = values.Id;
            return View();
        }
        [HttpPost]
        public IActionResult CevapVer(OgrenciSoruCevap ogrenciSoruCevap , int Id)
        {
            var userId = HttpContext.Session.GetInt32("userId");
            OgrenciSoruCevap ogr = new OgrenciSoruCevap();
            ogr.SoruId = Id;
            ogr.Cevap = ogrenciSoruCevap.Cevap;
            ogr.userId =Convert.ToInt32(userId);
            _c.ogrenciSoruCevaps.Add(ogr);
            _c.SaveChanges();
            return RedirectToAction("Sorularim");
        }
       
    }
}
