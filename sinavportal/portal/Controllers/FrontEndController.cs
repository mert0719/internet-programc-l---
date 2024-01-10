using Microsoft.AspNetCore.Mvc;

namespace portal.Controllers
{
    public class FrontEndController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
