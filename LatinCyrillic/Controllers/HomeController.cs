using LatinCyrillic.Models;
using Microsoft.AspNetCore.Mvc;

namespace LatinCyrillic.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LatinCryllic words)
        {

        }

    }
}
