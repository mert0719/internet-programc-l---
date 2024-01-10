using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using portal.Models;
using portal.ViewModel;

namespace portal.Controllers
{
    [Authorize]
    public class CevaplarController : Controller
    {
        private readonly Context _c;

        public CevaplarController(Context c)
        {
            _c = c;
        }

        public IActionResult Index()
        {
            var values = _c.cevaplars.Include(x=>x.Sorular)
                .Select(x => new CevapModel
                {
                    Id = x.Id,
                    Cevap = x.Cevap,
                    Soru = x.Sorular.Soru,
                }).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Cevaplar cevaplars_)
        {
            Cevaplar c = new Cevaplar();
            c.Cevap = cevaplars_.Cevap;
            c.SorularId = cevaplars_.SorularId;
            _c.cevaplars.Add(c);
            _c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Sil(int id)
        {
            var values = _c.cevaplars.Find(id);
            _c.cevaplars.Remove(values);
            _c.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Duzenle(int id)
        {
            var values = _c.cevaplars.Find(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Duzenle(Cevaplar cev, int id)
        {
            var values = _c.cevaplars.Find(id);
            values.Cevap = cev.Cevap;            
            _c.cevaplars.Update(values);
            _c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult SorularıGetir()
        {
            var values = _c.sorulars.ToList();
            return Json(values);
        }


    }
}
