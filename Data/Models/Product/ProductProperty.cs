using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class ProductProperty
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Title")]
        [MaxLength(256)]
        public string ProductPropertyTitle { get; set; }

        public ICollection<ProductPropertyRelation> ProductRelation { get; set; }


    }
}