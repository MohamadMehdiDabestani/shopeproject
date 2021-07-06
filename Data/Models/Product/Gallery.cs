using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        
        [MaxLength(150)]
        [Required]
        public string AltImage { get; set; }
        

        [MaxLength(150)]
        [Required]
        public string ImageName { get; set; }
        
        public int ProductId { get; set; }
        
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}