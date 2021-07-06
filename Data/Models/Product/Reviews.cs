using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter {0} .")]
        [MaxLength(300)]
        public string ReviewText { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public int ProductId { get; set; }
        
        public int UserId { get; set; }

        [ForeignKey("ProductId")]
        public Product product { get; set; }
        
        [ForeignKey("UserId")]
        public User user { get; set; }
    }
}