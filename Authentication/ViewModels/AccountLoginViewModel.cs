using System.ComponentModel.DataAnnotations;

namespace Authentication.ViewModels
{
    public class AccountLoginViewModel
    {
        [Required]
        [Display(Name ="User name")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
