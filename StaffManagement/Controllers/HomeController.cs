using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;
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
            return View();
        }
        public string Staff()
        {
            return _staffRepository.Get(3)?.FirstName;
        }

        public String Data()
        {
            return "Data dan salom";
        }
       
    }
}
