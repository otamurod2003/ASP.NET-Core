using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Authentication.Models
{
    public class Registration
    {
        [Required]
        [StringLength(50)]
        [Display(Name ="Email")]
        [RegularExpression(@"/^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$/")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()-_=+{}[\]|\\;:'"",.<>/?]).{5,}$")]
        public string Password { get; set; }
    }

}
