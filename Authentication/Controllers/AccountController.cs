using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
