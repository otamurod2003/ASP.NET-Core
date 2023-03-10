namespace StaffManagement.Models
{
    public class MockStaffRepository : IStaffRepository
    {
        private List<Staff> _staffs = null;
        public MockStaffRepository()
        {
            _staffs = new List<Staff>()
            {
                new Staff(){Id=1, FirstName="Otamurod", LastName="Pirnapasov", Email="otamurod@gmail.com", Department=Departments.Admin},
                new Staff(){Id=2, FirstName="Sulton", LastName="Qo'chqorov", Email="qochqor@gmail.com", Department=Departments.HR},
                new Staff(){Id=3, FirstName="Qayum", LastName="Mamatov", Email="qayum@gmail.com", Department=Departments.Production},

            };
        }
        public Staff Get(int id)
        {
            return _staffs.FirstOrDefault(staff => staff.Id.Equals(id));
        }

        public IEnumerable<Staff> GetAll()
        {
            return _staffs;
        }
        public Staff Create(Staff staff){
            staff.Id = _staffs.Max(s=> s.Id) + 1;
            _staffs.Add(staff);
            return staff;
        }
    }
}
