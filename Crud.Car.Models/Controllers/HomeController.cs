using Crud.Car.Models;
using Crud.Car.Models.Data;
using Crud.Car.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Car.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRepository _carRepo;

        public HomeController(ICarRepository carRepo) => _carRepo = carRepo;

        [HttpGet]
        public ViewResult Index()
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel()
            {
                Cars = _carRepo.GetAll(),
                Title = "Cars List",
            };
            return View(viewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HomeCreateViewModel car)
        {
            CarModel newCar = new CarModel()
            {
                Model = car.Model,
                Price = car.Price,
                CreatedDate = car.CreatedDate,
                Color = car.Color,
            };

            newCar = _carRepo.Create(newCar);
            return RedirectToAction("Index", new { id = car.Id });

        }
    }

}