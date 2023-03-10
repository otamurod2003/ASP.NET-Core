using System.ComponentModel.DataAnnotations;
namespace StaffManagement.Models
{
    public class Staff
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name= "First Name")]
        public string FirstName { get; set; }

        [MaxLength(50)]
         [Required]
         [Display(Name = "Last Name")]
        public string LastName { get; set; }

         [Required]
         [Display(Name = "Email")]
         [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$.",ErrorMessage ="Email is not valid")]
        public string Email { get; set; }


         [Required]
         [Display(Name ="Department")]
        public Departments? Department { get; set; }
    }
}
