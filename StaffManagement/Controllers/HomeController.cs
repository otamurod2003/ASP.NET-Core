using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;
using StaffManagement.ViewModel;
using System.Text.Json;

namespace StaffManagement.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IStaffRepository _staffRepository;
        public HomeController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        [Route("")]
        [Route("/")]
        [Route("[action]")]
        public ViewResult Index()
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel()
            {
                Staffs = _staffRepository.GetAll(),
                Title= "Staff List"
            };
            return View(viewModel); 
        }

        [Route("[action]/{id?}")]
       public ViewResult Details(int ? id)
        {
            HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
            {
                Staff = _staffRepository.Get(id ?? 1),
                Title = "Staff Details"
            };

           
            return View(viewModel);
        }
       
    }
}
