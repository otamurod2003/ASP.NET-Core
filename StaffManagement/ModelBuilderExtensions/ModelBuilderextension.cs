using Microsoft.EntityFrameworkCore;
using StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement.DataAccess.ModelBuilderExtensions
{
    public static class ModelBuilderextension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>().HasData(
                new Staff
                {
                    Id = 1,
                    FirstName = "Otamurod",
                    LastName = "Pirnapasov",
                    Email = "ota@gmail.com",
                    Department = Departments.Helper,
                  

                },
                 new Staff
                 {
                     Id = 2,
                     FirstName = "Hasan",
                     LastName = "Qabulov",
                     Email = "hasan@gmail.com",
                     Department = Departments.Admin,
                     
                 }
                );
        }
    }
}
