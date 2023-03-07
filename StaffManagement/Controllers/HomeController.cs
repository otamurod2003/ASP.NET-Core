using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;

namespace StaffManagement.Controllers
{
    public class HomeController : Controller
    {
        private  IStaffRepository _staffRepository;

        public HomeController()
        {
            _staffRepository = new MockStaffRepository();
        }
       

        public ViewResult Index()
        {
            return View();
        }

        public List<Staff> Staff()
        {
            return new List<Staff>();
        }
    }
}
 