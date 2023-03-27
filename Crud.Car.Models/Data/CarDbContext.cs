using Crud.Car.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Crud.Car.Models.Data
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options)
            :base(options) 
        {
            
        }

        public DbSet<CarModel> Cars{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>().HasData(
                new CarModel
                {
                    Id = 1,
                    Model="Malibu",
                    Price = 15000,
                    CreatedDate = DateTime.Now,
                    Color=Colors.Red
                },
                new CarModel
                {
                    Id = 2,
                    Model = "Moskvich",
                    Price = 500,
                    CreatedDate = DateTime.Now,
                    Color = Colors.Orange
                }
                );
        }

    }
}
