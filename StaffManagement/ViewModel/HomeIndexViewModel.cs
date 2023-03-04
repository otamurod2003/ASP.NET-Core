using StaffManagement.Models;

namespace StaffManagement.ViewModel
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Staff> Staffs { get; set; }
        public string  Title { get; set; }
    }
}
