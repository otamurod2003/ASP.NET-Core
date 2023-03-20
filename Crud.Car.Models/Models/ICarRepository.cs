namespace Crud.Car.Models
{
    public interface ICarRepository
    {
        CarModel Get(int id);
        IEnumerable<CarModel> GetAll();
        CarModel Create(CarModel car);
        CarModel Update(CarModel car);
        CarModel Delete(int id);
    }
}
