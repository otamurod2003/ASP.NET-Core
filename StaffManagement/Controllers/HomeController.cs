using Microsoft.AspNetCore.Mvc;

namespace StaffManagement.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult Data()
        {
            return Json(new { id = 1, name = "otamurod", lastname = "Pirnapasov" });

        }

        public ViewResult Index()
        {
            return View();
        }
    }
}
 