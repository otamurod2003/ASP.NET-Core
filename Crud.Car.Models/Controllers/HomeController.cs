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
            if (ModelState.IsValid)
            {
                CarModel newCar = new CarModel()
                {
                    Model = car.Model,
                    Price = car.Price,
                    CreatedDate = car.CreatedDate,
                    Color = car.Color,
                };
               newCar = _carRepo.Create(newCar);
                return RedirectToAction("index", new { Id = car.Id });
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ViewResult Details(int id)
        {

            CarModel car = _carRepo.Get(id);
            if (car is not null)
            {
                HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
                {
                    Car = car,
                    Title = "Car details"
                };
                return View(viewModel);
            }
            else
            {
                return CarNotFound(id);
            }

        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            CarModel car = _carRepo.Get(id);
            if (car is not null)
            {


                HomeEditViewModel viewModel = new HomeEditViewModel()
                {
                    Id = car.Id,
                    Model = car.Model,
                    Price = car.Price,
                    CreatedDate = car.CreatedDate,
                    Color = car.Color,

                };
                return View(viewModel);
            }
            else { return CarNotFound(id); }
        }
        [HttpPost]
        public IActionResult Edit(HomeEditViewModel car)
        {
            if (ModelState.IsValid)
            {
                CarModel existingCar = _carRepo.Get(car.Id);
                existingCar.Model = car.Model;
                existingCar.Price = car.Price;
                existingCar.CreatedDate = car.CreatedDate;
                existingCar.Color = car.Color;
                _carRepo.Update(existingCar);
                return RedirectToAction("Index");

            }
            return View();

        }
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _carRepo.Delete(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Details");
        }

        public ViewResult CarNotFound(int id)
        {
            Response.StatusCode = 404;
            return View("CarNotFound", id);
        }
    }


}