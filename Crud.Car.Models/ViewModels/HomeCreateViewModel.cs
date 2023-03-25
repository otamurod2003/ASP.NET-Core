using Crud.Car.Models;
using System.ComponentModel.DataAnnotations;

namespace Crud.Car.ViewModels
{
    public class HomeCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required]
        [Range(1,100000000000)]
        [Display(Name = "Price")]
        public int Price { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Release date is not required")]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage="Color is not required...")]
        [Display(Name = "Color")]
        public Colors Color { get; set; }
    }
}
