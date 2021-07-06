using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class ProductPropertyRelation
    {
        [Key]
        public int PP_ID { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Propert Value")]
        [MaxLength(150)]
        public string Value { get; set; }

        public int ProductId { get; set; }

        public int ProductPropertId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("ProductPropertId")]
        public ProductProperty ProductProperty { get; set; }


    }
}