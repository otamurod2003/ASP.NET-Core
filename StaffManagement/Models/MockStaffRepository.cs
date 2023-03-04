namespace StaffManagement.Models
{
    public class MockStaffRepository: IStaffRepository
    {
        private List<Staff> _staffs = null;
        public MockStaffRepository()
        {
            _staffs = new List<Staff>()
           {
               new Staff(){Id=1, FirstName="Otamurod",LastName="Pirnapasov",Email="otamurod@gmail.com", Department="Aministrator"},
               new Staff(){Id=2, FirstName="Boyxoja",LastName="Eshonxo'jayev",Email="boyxoja@gmail.com", Department="Helper"},
               new Staff(){Id=3, FirstName="Nikol",LastName="Pashinyan",Email="pashinyan@gmail.com", Department="Production"},
           };
           
  
        }
        public Staff Get(int id)
        {
            return _staffs.FirstOrDefault(staff => staff.Id.Equals(id));
        }

       
    }
}
