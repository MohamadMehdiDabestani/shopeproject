using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        
        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Group Title")]
        [MaxLength(200)]
        public string GroupTitle { get; set; }
        
        public int? ParentId { get; set; }
        
        [ForeignKey("ParentId")]
        public List<Group> SubId { get; set; }

        [InverseProperty("GroupProduct")]
        public List<Product> Products { get; set; }
        
        [InverseProperty("SubGroupProduct")]
        public List<Product> SubProducts { get; set; }
    }
}