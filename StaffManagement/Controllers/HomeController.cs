using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.DataAccess;
using StaffManagement.Models;
using StaffManagement.ViewModels;

namespace StaffManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IWebHostEnvironment webHost;

        public HomeController(IStaffRepository staffRepository, IWebHostEnvironment webHost)
        {
            _staffRepository = staffRepository;
            this.webHost = webHost;
        }
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
        public IActionResult Create(HomeCreateViewModel staff)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadFile(staff);
                Staff newStaff = new Staff
                {
                    LastName = staff.FirstName,
                    FirstName = staff.LastName,
                    Email = staff.Email,
                    Department = staff.Department,
                    PhotoFilePath = uniqueFileName
                };
                newStaff = _staffRepository.Create(newStaff);
                return RedirectToAction("details", new { id = newStaff.Id });
            }
            return View();
        }

        
        [HttpGet]
        public ViewResult Edit(int? id)
        {
            Staff staff = _staffRepository.Get(id ?? 1);
            HomeEditViewModel editViewModel = new HomeEditViewModel()
            {
                Id = staff.Id,
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                Email = staff.Email,
                Department = staff.Department,
                ExistingPhotoFilePath = staff.PhotoFilePath,
            };
            return View(editViewModel);
        }
        [HttpPost]
        public IActionResult Edit(HomeEditViewModel staff)
        {
            if (ModelState.IsValid)
            {
                Staff existingStaff = _staffRepository.Get(staff.Id);
                existingStaff.FirstName = staff.FirstName;
                existingStaff.LastName = staff.LastName;
                existingStaff.Email = staff.Email;
                existingStaff.Department = staff.Department;
                if (staff.Photo != null)
                {
                    if(staff.ExistingPhotoFilePath != null)
                    {
                        var filePath = Path.Combine(webHost.WebRootPath,"images",staff.ExistingPhotoFilePath);
                        System.IO.File.Delete(filePath);
                    }
                    existingStaff.PhotoFilePath = ProcessUploadFile(staff);
                }
                _staffRepository.Update(existingStaff);
                return RedirectToAction("index");
            }
            return View();
            
        }

        private string ProcessUploadFile(HomeCreateViewModel staff)
        {
            string uniqueFileName = string.Empty;
            if (staff.Photo != null)
            {
                string uploadFolder = Path.Combine(webHost.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + staff.Photo.FileName;
                string imageFilePath = Path.Combine(uploadFolder, uniqueFileName);
                staff.Photo.CopyTo(new FileStream(imageFilePath, FileMode.Create));
            }

            return uniqueFileName;
        }


    }
}
