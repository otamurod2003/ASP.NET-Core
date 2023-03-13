using Microsoft.EntityFrameworkCore;
using StaffManagement.DataAccess.ModelBuilderExtensions;
using StaffManagement.Models;

namespace StaffManagement.DataAccess
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>  options)
            : base(options)
        {
            
        }
        public DbSet<Staff> Staffs { get; set; }

        public IEnumerable<Staff> GetAll()
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

    }
}
