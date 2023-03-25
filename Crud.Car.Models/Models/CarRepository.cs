using Crud.Car.Models.Data;

namespace Crud.Car.Models
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDbContext _context;

        public CarRepository(CarDbContext context)=> _context = context;
        
        CarModel ICarRepository.Create(CarModel car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return car;
        }

        CarModel ICarRepository.Delete(int id)
        {

            CarModel? car = _context.Cars.Find(id);
            _context.Cars.Remove(car);
            _context.SaveChanges();
            return car;
        }

        CarModel ICarRepository.Get(int id)
        {
            return _context.Cars.Find(id);
        }

        IEnumerable<CarModel> ICarRepository.GetAll()
        {
            return _context.Cars;
        }

        CarModel ICarRepository.Update(CarModel updatedCar)
        {
            var car = _context.Cars.Attach(updatedCar);
           car.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updatedCar;
        }
    }
}
