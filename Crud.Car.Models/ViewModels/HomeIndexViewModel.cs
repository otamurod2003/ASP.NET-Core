using Crud.Car.Models;
namespace Crud.Car.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<CarModel>  Cars { get; set; }
        public string Title { get; set; }
    }
}
