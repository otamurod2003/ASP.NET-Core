using Microsoft.EntityFrameworkCore;
using StaffManagement.DataAccess.ModelBuilderExtensions;
using StaffManagement.Models;

namespace StaffManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Staff> Staffs { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

    }
}
