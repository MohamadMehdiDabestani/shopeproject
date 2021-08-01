using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Carousel
    {
        public int Id { get; set; }

    [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Title")]
        [MaxLength(100)]
        public string Title { get; set; }

            [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Text")]
        [MaxLength(200)]
        public string Text { get; set; }

         [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Price")]
        public int Price { get; set; }

    [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Link")]
        [MaxLength(200)]
        public string Link { get; set; }

        [Required]
        [MaxLength(150)]
        public string Image { get; set; }
    }
}