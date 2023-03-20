using System.ComponentModel.DataAnnotations;

namespace Crud.Car.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        [Display(Name ="Model")]
        public string Model { get; set; }

        [Required]
        [MaxLength(60)]
        [Display(Name = "Price")]
        public int Price { get; set; }

        [Required]
        [MaxLength(60)]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(60)]
        [Display(Name = "Color")]
        public Colors Color { get; set;}

        
    }
}
