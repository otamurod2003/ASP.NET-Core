using Microsoft.AspNetCore.Mvc;
using StaffManagement.DataAccess;
using StaffManagement.Models;
using StaffManagement.ViewModels;

namespace StaffManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStaffRepository _staffRepository;
        public HomeController(IStaffRepository staffRepository) => _staffRepository = staffRepository;
        public ViewResult Index()
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel()
            {
                Staffs = _staffRepository.GetAll(),
                Title = "Staff List",
            };
            return View(viewModel);
        }
        public IActionResult Details(int? id)
        {
            HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
            {
                Staff = _staffRepository.Get(id ?? 1),
                Title = "Staff details",
            };
            return View(viewModel);
            
        }

    [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Staff staff){
            if(ModelState.IsValid){
           var newStaff =  _staffRepository.Create(staff);
            return RedirectToAction("details", new{id=newStaff.Id});
            }else
            return View();
        }
       
    }
}
 