using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;
using StaffManagement.ViewModel;
using System.Text.Json;

namespace StaffManagement.Controllers
{
    public class HomeController: Controller
    {
        private readonly IStaffRepository _staffRepository;
        public HomeController(IStaffRepository staffRepository)
        {
            _staffRepository= staffRepository;
        }
        public ViewResult Index()
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel()
            {
                Staffs = _staffRepository.GetAll()
            };
            return View(viewModel); 
        }

       public ViewResult Details()
        {
            HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
            {
                Staff = _staffRepository.Get(1),
                Title = "Staff Details"
            };

           
            return View(viewModel);
        }
       
    }
}
