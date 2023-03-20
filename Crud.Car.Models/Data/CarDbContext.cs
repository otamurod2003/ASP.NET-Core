using Crud.Car.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Car.Models.Data
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options)
            :base(options) 
        {
            
        }

        public DbSet<CarModel> Cars{ get; set; }

    }
}
