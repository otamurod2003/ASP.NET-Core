namespace StaffManagement.Models
{
    public class SqlserverRepository : IStaffRepository
    {
        private List<Staff> _staffs;
        public SqlserverRepository()
        {
            _staffs = new List<Staff>()
            {
                new Staff(){Id=1, FirstName="Otamurod", LastName="Pirnapasov", Email="otamurod@gmail.com", Department=Departments.Admin},
                new Staff(){Id=2, FirstName="Sulton", LastName="Qo'chqorov", Email="qochqor@gmail.com", Department=Departments.HR},
                new Staff(){Id=3, FirstName="Qayum", LastName="Mamatov", Email="qayum@gmail.com", Department=Departments.Production},

            };
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

        public Staff Get(int id)
        {
            return _staffs.FirstOrDefault(staff => staff.Id.Equals(id));
        }

        public Staff Update(Staff updatedStaff)
        {
            var staff = _staffs.FirstOrDefault(s => s.Id.Equals(updatedStaff.Id));
            if (staff != null)
            {
                staff.FirstName = updatedStaff.FirstName;
                staff.LastName = updatedStaff.LastName;
                staff.Email = updatedStaff.Email;
                staff.Department = updatedStaff.Department;
            }
            return updatedStaff;
        }

        public Staff Delete(int id)
        {
            var staff = _staffs.FirstOrDefault(s => s.Id.Equals(id));
            if(staff != null)
            {
                _staffs.Remove(staff);
            }
            return staff;
        }
    }
}
