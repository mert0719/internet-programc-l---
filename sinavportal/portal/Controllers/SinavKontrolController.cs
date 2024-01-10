using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using portal.Models;
using portal.ViewModel;

namespace portal.Controllers
{
    public class SinavKontrolController : Controller
    {
        private readonly Context _c;

        public SinavKontrolController(Context c)
        {
            _c = c;
        }

        public IActionResult Index()
        {

            var groupedValues = _c.ogrenciSoruCevaps
                .Include(x => x.User)
                .GroupBy(x => x.userId) // AppUserId'ye göre gruplama
                .Select(group => new OgrenciCevapGrupModel
                {

                    Adi = group.First().User.Adi,
                    Soyadi = group.First().User.Soyadi,
                    Id = group.First().Id,
                    UserId = group.Key,
                })
                .ToList();

            return View(groupedValues);
                       
        }



        public IActionResult CevapDetay(int id)
        {

            var values = _c.ogrenciSoruCevaps.Where(x=>x.userId == id).Include(x => x.Soru).Include(x => x.User)
                .Select(x => new OgrenciSoruCevapModel
                {
                    Id = x.Id,
                    Soru = x.Soru.Soru,
                    Cevap = x.Cevap,
                    SoruPuan = x.Soru.SoruPuani,
                    CevapPuani = x.CevapPuani,
                    userId = x.User.Id,
                }).ToList();
            return View(values);
        }

        public IActionResult PuanVer(int id, int CevapPuani)
        {
            var values = _c.ogrenciSoruCevaps.Find(id);
            values.CevapPuani = CevapPuani;
            _c.ogrenciSoruCevaps.Update(values);
            _c.SaveChanges();
            return Json(values);
        }
    }
}
