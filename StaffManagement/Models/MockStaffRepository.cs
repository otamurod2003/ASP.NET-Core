namespace StaffManagement.Models
{
    public class MockStaffRepository : IStaffRepository
    {
        private List<Staff> _staffs = null;
        public MockStaffRepository()
        {
            _staffs = new List<Staff>()
            {
                new Staff(){Id=1, FirstName="Otamurod", LastName="Pirnapasov", Email="otamurod@gmail.com", Department="Admin"},
                new Staff(){Id=2, FirstName="Sulton", LastName="Qo'chqorov", Email="qochqor@gmail.com", Department="Production"},
                new Staff(){Id=3, FirstName="Qayum", LastName="Mamatov", Email="qayum@gmail.com", Department="Saler"},

            };
        }
        public Staff Get(int id)
        {
            return _staffs.FirstOrDefault(staff => staff.Equals(id));
        }
    }
}
